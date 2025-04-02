using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.UpdateExecutors.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Services.Updaters.Executors;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.States.Statuses;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.UpdateExecutors;

[UsedImplicitly]
internal sealed class UpdateExecutorsEntitiesSigningWorkflowRequestInternalHandler : IRequestHandler<UpdateExecutorsEntitiesSigningWorkflowRequestInternal>
{
    public UpdateExecutorsEntitiesSigningWorkflowRequestInternalHandler(
        SigningWorkflowsFacade workflows,
        ILogger<UpdateExecutorsEntitiesSigningWorkflowRequestInternalHandler> logger)
    {
        Workflows = workflows;
        Logger = logger;
    }

    private SigningWorkflowsFacade Workflows { get; }
    private ILogger<UpdateExecutorsEntitiesSigningWorkflowRequestInternalHandler> Logger { get; }

    public async Task Handle(UpdateExecutorsEntitiesSigningWorkflowRequestInternal request, CancellationToken cancellationToken)
    {
        Id<SigningWorkflow> workflowId = IdConverterFrom<SigningWorkflow>.From(request.WorkflowId);

        SigningWorkflow workflow = await Workflows.GetRequired(workflowId, cancellationToken);

        if (IsProcessingShallBeSkipped(workflow))
        {
            return;
        }

        Id<User> executorId = IdConverterFrom<User>.From(request.ExecutorId);

        SigningWorkflowExecutorsUpdater.Update(workflow, executorId);

        await Workflows.Upsert(workflow, cancellationToken);
    }

    private static bool IsProcessingShallBeSkipped(SigningWorkflow workflow)
    {
        if (workflow.Status is SigningStatus.Completed)
        {
            return true;
        }

        return false;
    }
}
