using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Repositories.Workflows;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services;

public sealed class ApprovalWorkflowsFacade(
    IApprovalWorkflowsRepository workflowsRepository,
    IEnumerable<IApprovalWorkflowApplicationEventProcessor> processors,
    ILogger<ApprovalWorkflowsFacade> logger)
{
    private const int RetryCount = 10;
    private const int BatchSize = 500;

    public async Task Upsert(ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        workflow = await Update(workflow, cancellationToken);

        await Process(workflow, true, cancellationToken);
    }

    public Task<Id<ApprovalWorkflow>[]> GetAllActiveIds(UtcDateTime<ApprovalWorkflowState> actualizeDate, CancellationToken cancellationToken)
    {
        var result = workflowsRepository.GetAllActiveIds(actualizeDate, cancellationToken);

        return result;
    }

    public async Task<ApprovalWorkflow[]> GetByEntityId(Id<ApprovalWorkflowEntity> entityId, bool processApplicationsEvents, CancellationToken cancellationToken)
    {
        var workflowsIds = await workflowsRepository.GetIds(entityId, cancellationToken);

        ApprovalWorkflow[] workflows = await GetByIds(workflowsIds, processApplicationsEvents, cancellationToken);

        return workflows;
    }

    public async Task<ApprovalWorkflow[]> GetByIds(Id<ApprovalWorkflow>[] workflowsIds, bool processApplicationsEvents, CancellationToken cancellationToken)
    {
        var tasks = workflowsIds.Chunk(BatchSize)
            .Select(batch => GetApprovalWorkflowsBatch(batch, processApplicationsEvents, cancellationToken))
            .ToList();

        Dictionary<Id<ApprovalWorkflow>, ApprovalWorkflow> workflows = (await Task.WhenAll(tasks)).SelectMany(x => x).ToDictionary(x => x.Id);

        ApprovalWorkflow[] result = workflowsIds.Select(w => workflows[w]).ToArray();

        return result;
    }

    private async Task<ApprovalWorkflow[]> GetApprovalWorkflowsBatch(Id<ApprovalWorkflow>[] ids, bool processApplicationsEvents, CancellationToken cancellationToken)
    {
        var workflows = await workflowsRepository.GetBatch(ids, cancellationToken);

        if (workflows.Length != ids.Length)
        {
            HashSet<Id<ApprovalWorkflow>> foundIds = workflows.Select(x => x.Id).ToHashSet();
            Id<ApprovalWorkflow>? notFoundId = ids.FirstOrDefault(x => !foundIds.Contains(x));

            throw new ApplicationException($"Approval workflow with id {notFoundId} is not found");
        }

        IEnumerable<Task<ApprovalWorkflow>> processTasks = workflows.Select(w => Process(w, processApplicationsEvents, cancellationToken));

        workflows = await Task.WhenAll(processTasks);

        return workflows;
    }

    public async Task<ApprovalWorkflow> GetRequired(Id<ApprovalWorkflow> workflowId, bool processApplicationsEvents, CancellationToken cancellationToken)
    {
        var workflow = await Get(workflowId, processApplicationsEvents, cancellationToken);

        if (workflow is null)
        {
            throw new ApplicationException(
                $"""
                 Approval workflow is not found.
                 WorkflowId: {workflowId}
                 """);
        }

        return workflow;
    }

    public async Task<ApprovalWorkflow?> Get(Id<ApprovalWorkflow> workflowId, bool processApplicationsEvents, CancellationToken cancellationToken)
    {
        var workflow = await workflowsRepository.Get(workflowId, cancellationToken);

        if (workflow is null)
        {
            return null;
        }

        workflow = await Process(workflow, processApplicationsEvents, cancellationToken);

        return workflow;
    }

    private async Task<ApprovalWorkflow> Process(ApprovalWorkflow workflow, bool processApplicationsEvents, CancellationToken cancellationToken)
    {
        if (processApplicationsEvents)
        {
            workflow = await ProcessApplicationEvents(workflow, cancellationToken);
        }

        return workflow;
    }

    private async Task<ApprovalWorkflow> ProcessApplicationEvents(ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        Exception? processException = null;

        for (var i = 1; i < RetryCount; i++)
        {
            if (workflow.ApplicationEvents.Count == 0)
            {
                return workflow;
            }

            (var isApplicationEventsProcessed, processException) = await ProcessApplicationEvents(workflow, i, cancellationToken);

            if (isApplicationEventsProcessed)
            {
                workflow.ApplicationEvents.Clear();

                workflow = await Update(workflow, cancellationToken);
            }
            else
            {
                workflow = await workflowsRepository.GetRequired(workflow.Id, cancellationToken);
            }
        }

        throw new ApplicationException(
            $"""
             APPLICATION EVENTS FAILURE: Failed to process.
             WorkflowId: {workflow.Id}
             """,
            processException);
    }

    private async Task<(bool, Exception?)> ProcessApplicationEvents(ApprovalWorkflow workflow, int attempt, CancellationToken cancellationToken)
    {
        try
        {
            var counter = 1;

            foreach (var applicationEvent in workflow.ApplicationEvents)
            {
                await ProcessApplicationEvent(attempt, counter++, applicationEvent, workflow, cancellationToken);
            }
        }
        catch (Exception e)
        {
            return (false, e);
        }

        return (true, null);
    }

    private async Task ProcessApplicationEvent(
        int attempt,
        int counter,
        ApprovalWorkflowApplicationEvent applicationEvent,
        ApprovalWorkflow workflow,
        CancellationToken cancellationToken)
    {
        var counts = $"{attempt}:{counter}/{workflow.ApplicationEvents.Count}";

        try
        {
            logger.LogInformation(
                """
                APPLICATION EVENT [{Counts:l}] START: 🔷 {ApplicationEvent:l}
                Workflow: {@Workflow}
                """,
                counts,
                applicationEvent,
                workflow);

            foreach (var processor in processors)
            {
                await processor.Process(counter, applicationEvent, workflow, cancellationToken);
            }

            logger.LogInformation(
                """
                APPLICATION EVENT [{Counts:l}] END: {ApplicationEvent:l}
                Workflow: {@Workflow}
                """,
                counts,
                applicationEvent,
                workflow);
        }
        catch (Exception e)
        {
            logger.LogError(
                e,
                """
                APPLICATION EVENT [{Counts:l}] ERROR: ❌ {ApplicationEvent:l} {@Message}
                Workflow: {@Workflow}
                """,
                counts,
                applicationEvent,
                e.Message,
                workflow);

            throw;
        }
    }

    private async Task<ApprovalWorkflow> Update(ApprovalWorkflow workflow, CancellationToken cancellationToken)
    {
        await workflowsRepository.Upsert(workflow, cancellationToken);

        var result = await workflowsRepository.GetRequired(workflow.Id, cancellationToken);

        return result;
    }
}
