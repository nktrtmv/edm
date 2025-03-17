using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Detectors.Statuses;

internal static class ApprovalWorkflowStatusesDetector
{
    internal static (ApprovalWorkflowStageStatus, ApprovalWorkflowStatus) Detect(ApprovalWorkflowAssignmentCompletionReason completionReason)
    {
        (ApprovalWorkflowStageStatus, ApprovalWorkflowStatus) result = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReason.Approved => (ApprovalWorkflowStageStatus.Approved, ApprovalWorkflowStatus.Approved),
            ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark => (ApprovalWorkflowStageStatus.ApprovedWithRemark, ApprovalWorkflowStatus.ApprovedWithRemark),
            ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework => (ApprovalWorkflowStageStatus.ReturnedToRework, ApprovalWorkflowStatus.ReturnedToRework),
            ApprovalWorkflowAssignmentCompletionReason.Rejected => (ApprovalWorkflowStageStatus.Rejected, ApprovalWorkflowStatus.Rejected),
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
