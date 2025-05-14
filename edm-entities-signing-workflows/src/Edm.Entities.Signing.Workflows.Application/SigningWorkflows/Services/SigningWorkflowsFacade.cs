using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Repositories.SigningWorkflows;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;

public sealed class SigningWorkflowsFacade
{
    private const int RetryCount = 10;

    public SigningWorkflowsFacade(
        ISigningWorkflowsRepository workflows,
        IEnumerable<ISigningApplicationEventProcessor> processors,
        ILogger<SigningWorkflowsFacade> logger)
    {
        Workflows = workflows;
        Processors = processors;
        Logger = logger;
    }

    private ISigningWorkflowsRepository Workflows { get; }
    private IEnumerable<ISigningApplicationEventProcessor> Processors { get; }
    private ILogger<SigningWorkflowsFacade> Logger { get; }

    public async Task<SigningWorkflow?> Get(Id<SigningWorkflow> workflowId, CancellationToken cancellationToken)
    {
        SigningWorkflow? result = await GetProcessed(workflowId, cancellationToken);

        return result;
    }

    public async Task<SigningWorkflow> GetRequired(Id<SigningWorkflow> workflowId, CancellationToken cancellationToken)
    {
        SigningWorkflow? workflow = await GetProcessed(workflowId, cancellationToken);

        if (workflow is null)
        {
            throw new ApplicationException($"Package for workflow (id: {workflowId}) is not found.");
        }

        return workflow;
    }

    public async Task Upsert(SigningWorkflow workflow, CancellationToken cancellationToken)
    {
        await Workflows.Upsert(workflow, cancellationToken);

        await GetProcessed(workflow.Id, cancellationToken);
    }

    private async Task<SigningWorkflow?> GetProcessed(Id<SigningWorkflow> workflowId, CancellationToken cancellationToken)
    {
        for (var i = 0; i < RetryCount; i++)
        {
            SigningWorkflow? workflow = await Workflows.Get(workflowId, cancellationToken);

            if (workflow is null)
            {
                return null;
            }

            bool isApplicationEventsProcessed = await ProcessApplicationEvents(workflow, cancellationToken);

            if (isApplicationEventsProcessed)
            {
                continue;
            }

            return workflow;
        }

        throw new ApplicationException($"APPLICATION EVENTS FAILURE: Failed to process, workflow (id: {workflowId}).");
    }

    private async Task<bool> ProcessApplicationEvents(SigningWorkflow workflow, CancellationToken cancellationToken)
    {
        if (workflow.ApplicationEvents.Count == 0)
        {
            return false;
        }

        try
        {
            var i = 0;

            foreach (SigningApplicationEvent applicationEvent in workflow.ApplicationEvents)
            {
                var counts = $"{++i}/{workflow.ApplicationEvents.Count}";

                await ProcessApplicationEvent(counts, applicationEvent, workflow, cancellationToken);
            }

            workflow.ApplicationEvents.Clear();

            await Workflows.Upsert(workflow, cancellationToken);
        }
        catch
        {
            // ignored
        }

        return true;
    }

    private async Task ProcessApplicationEvent(
        string counts,
        SigningApplicationEvent applicationEvent,
        SigningWorkflow workflow,
        CancellationToken cancellationToken)
    {
        try
        {
            Logger.LogInformation("APPLICATION EVENT [{Counts}] START : Event: {@Event}, Workflow: {@Workflow}", counts, applicationEvent, workflow);

            foreach (ISigningApplicationEventProcessor processor in Processors)
            {
                await processor.Process(applicationEvent, workflow, cancellationToken);
            }

            Logger.LogInformation("APPLICATION EVENT [{Counts}] END: Event: {@Event}, Workflow: {@Workflow}", counts, applicationEvent, workflow);
        }
        catch (Exception e)
        {
            Logger.LogError(
                e,
                "APPLICATION EVENT [{Counts}] ERROR: Reason: {@Message}, Event: {@Event}, Workflow: {@Workflow}",
                counts,
                e.Message,
                applicationEvent,
                workflow);

            throw;
        }
    }

    private async Task<SigningWorkflow> Update(SigningWorkflow workflow, CancellationToken cancellationToken)
    {
        await Workflows.Upsert(workflow, cancellationToken);

        SigningWorkflow result = await Workflows.GetRequired(workflow.Id, cancellationToken);

        return result;
    }
}
