using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts.Factories;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands;

[UsedImplicitly]
public abstract class EntitiesApprovalWorkflowsActionsCommandInternalHandler<T>(ApprovalWorkflowsFacade workflows) : IRequestHandler<T> where T : ActionsCommandInternal
{
    public async Task Handle(T request, CancellationToken cancellationToken)
    {
        var workflowId = IdConverterFrom<ApprovalWorkflow>.From(request.Context.WorkflowId);

        var workflow = await workflows.GetRequired(workflowId, true, cancellationToken);

        Id<Employee> currentUserId = IdConverterFrom<Employee>.From(request.Context.CurrentUserId);

        Id<ApprovalWorkflowStage> stageId = IdConverterFrom<ApprovalWorkflowStage>.From(request.Context.StageId);

        var context =
            ApprovalWorkflowActionContextFactory.CreateFrom(
                workflow,
                stageId,
                currentUserId,
                request.Context.CurrentUserIsOwner,
                request.Context.CurrentUserIsAdmin);

        await Process(request, context, cancellationToken);

        var action = request.DryRunAndLock
            ? LockAndUpsert(workflow, cancellationToken)
            : UnlockAndUpsert(workflow, cancellationToken);

        await action;
    }

    protected abstract Task Process(T command, ApprovalWorkflowActionContext context, CancellationToken cancellationToken);

    private async Task LockAndUpsert(ApprovalWorkflow processedWorkflow, CancellationToken cancellationToken)
    {
        var originalWorkflow = await workflows.GetRequired(processedWorkflow.Id, false, cancellationToken);

        const bool isLocked = true;

        var workflow = ApprovalWorkflowFactory.CreateFrom(originalWorkflow, processedWorkflow.Audit, isLocked);

        await workflows.Upsert(workflow, cancellationToken);
    }

    private async Task UnlockAndUpsert(ApprovalWorkflow processedWorkflow, CancellationToken cancellationToken)
    {
        const bool isLocked = false;

        var workflow = ApprovalWorkflowFactory.CreateFrom(processedWorkflow, isLocked);

        await workflows.Upsert(workflow, cancellationToken);
    }
}
