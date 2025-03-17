using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Complete.Contracts;

public sealed record CompleteEntitiesApprovalWorkflowsActionsCommandInternal(
    ApprovalWorkflowActionContextInternal Context,
    ApprovalWorkflowAssignmentCompletionReasonInternal CompletionReason,
    string? CompletionComment,
    bool DryRunAndLock)
    : ActionsCommandInternal(Context, DryRunAndLock);
