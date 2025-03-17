using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Detectors;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;

using ApprovalWorkflowAssignment =
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.
    ApprovalWorkflowAssignment;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors.Executors;

internal static class AvailableExecutorApprovalWorkflowActionsDetector
{
    private static readonly ApprovalWorkflowActionKind[] NoAvailableActions = Array.Empty<ApprovalWorkflowActionKind>();

    private static readonly ApprovalWorkflowActionKind[] TakeInWorkActions = { ApprovalWorkflowActionKind.TakeInWork };

    private static readonly ApprovalWorkflowActionKind[] DocumentAuthorDisabledActions =
    [
        ApprovalWorkflowActionKind.Approve,
        ApprovalWorkflowActionKind.ApproveWithRemark
    ];

    private static ApprovalWorkflowActionKind[] ExecutorsActions(bool approvingWithRemarkIsDisabled)
    {
        return approvingWithRemarkIsDisabled
            ? new[]
            {
                ApprovalWorkflowActionKind.Approve,
                ApprovalWorkflowActionKind.ReturnToRework,
                ApprovalWorkflowActionKind.Reject,
                ApprovalWorkflowActionKind.Delegate
            }
            : new[]
            {
                ApprovalWorkflowActionKind.Approve,
                ApprovalWorkflowActionKind.ApproveWithRemark,
                ApprovalWorkflowActionKind.ReturnToRework,
                ApprovalWorkflowActionKind.Reject,
                ApprovalWorkflowActionKind.Delegate
            };
    }

    internal static ApprovalWorkflowActionKind[] Detect(ApprovalWorkflowActionContext context)
    {
        var activeGroup = ActiveGroupApprovalWorkflowsDetector.Get(context.ActiveGroups, context.CurrentUserId);

        if (activeGroup is null)
        {
            return NoAvailableActions;
        }

        ApprovalWorkflowAssignment[] userActiveAssignments = activeGroup.Assignments
            .Where(a => a.ExecutorId == context.CurrentUserId)
            .Where(a => a.IsActive)
            .ToArray();

        var userHasNotStartedAssignments = userActiveAssignments.Any(a => a.Status == ApprovalWorkflowAssignmentStatus.NotStarted);

        var result = userHasNotStartedAssignments
            ? TakeInWorkActions
            : ExecutorsActions(context.Workflow.Parameters.Options.ApprovingWithRemarkIsDisabled);

        return result;
    }
}
