using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Complete.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.StageActivators;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;

using JetBrains.Annotations;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Complete;

[UsedImplicitly]
internal class CompleteEntitiesApprovalWorkflowsActionsCommandInternalHandler(
    ApprovalWorkflowsFacade workflows,
    ApprovalWorkflowStageActivator activator)
    : EntitiesApprovalWorkflowsActionsCommandInternalHandler<CompleteEntitiesApprovalWorkflowsActionsCommandInternal>(workflows)
{
    private ApprovalWorkflowStageActivator Activator { get; } = activator;

    protected override async Task Process(
        CompleteEntitiesApprovalWorkflowsActionsCommandInternal command,
        ApprovalWorkflowActionContext context,
        CancellationToken cancellationToken)
    {
        var completionReason =
            ApprovalWorkflowAssignmentCompletionReasonInternalConverter.ToDomain(command.CompletionReason);

        CompleteApprovalWorkflowsActionsCommandProcessor.Complete(context, completionReason, command.CompletionComment);

        await Activator.TryActivate(context.Workflow, cancellationToken);
    }
}
