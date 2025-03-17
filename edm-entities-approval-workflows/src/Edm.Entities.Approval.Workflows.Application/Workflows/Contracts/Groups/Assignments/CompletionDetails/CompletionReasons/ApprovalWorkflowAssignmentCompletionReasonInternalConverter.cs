using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.
    CompletionReasons;

internal static class ApprovalWorkflowAssignmentCompletionReasonInternalConverter
{
    internal static ApprovalWorkflowAssignmentCompletionReasonInternal FromDomain(ApprovalWorkflowAssignmentCompletionReason completionReason)
    {
        ApprovalWorkflowAssignmentCompletionReasonInternal result = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReason.Approved => ApprovalWorkflowAssignmentCompletionReasonInternal.Approved,
            ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark => ApprovalWorkflowAssignmentCompletionReasonInternal.ApprovedWithRemark,
            ApprovalWorkflowAssignmentCompletionReason.Delegated => ApprovalWorkflowAssignmentCompletionReasonInternal.Delegated,
            ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework => ApprovalWorkflowAssignmentCompletionReasonInternal.ReturnedToRework,
            ApprovalWorkflowAssignmentCompletionReason.Rejected => ApprovalWorkflowAssignmentCompletionReasonInternal.Rejected,
            ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically => ApprovalWorkflowAssignmentCompletionReasonInternal.CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }

    internal static ApprovalWorkflowAssignmentCompletionReason ToDomain(ApprovalWorkflowAssignmentCompletionReasonInternal completionReason)
    {
        ApprovalWorkflowAssignmentCompletionReason result = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReasonInternal.Approved => ApprovalWorkflowAssignmentCompletionReason.Approved,
            ApprovalWorkflowAssignmentCompletionReasonInternal.ApprovedWithRemark => ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark,
            ApprovalWorkflowAssignmentCompletionReasonInternal.ReturnedToRework => ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework,
            ApprovalWorkflowAssignmentCompletionReasonInternal.Rejected => ApprovalWorkflowAssignmentCompletionReason.Rejected,
            ApprovalWorkflowAssignmentCompletionReasonInternal.Delegated => ApprovalWorkflowAssignmentCompletionReason.Delegated,
            ApprovalWorkflowAssignmentCompletionReasonInternal.CompletedAutomatically => ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
