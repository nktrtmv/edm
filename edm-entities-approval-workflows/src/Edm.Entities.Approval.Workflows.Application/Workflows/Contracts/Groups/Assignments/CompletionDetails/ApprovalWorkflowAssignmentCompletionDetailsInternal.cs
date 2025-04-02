using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.DelegationDetails;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.
    CompletionDetails;

public sealed class ApprovalWorkflowAssignmentCompletionDetailsInternal
{
    public ApprovalWorkflowAssignmentCompletionDetailsInternal(
        ApprovalWorkflowAssignmentCompletionReasonInternal completionReason,
        UtcDateTime<ApprovalWorkflowAssignmentInternal> completedDate,
        string? completionComment,
        ApprovalWorkflowAssignmentDelegationDetailsInternal? delegationDetails)
    {
        CompletionReason = completionReason;
        CompletedDate = completedDate;
        CompletionComment = completionComment;
        DelegationDetails = delegationDetails;
    }

    public ApprovalWorkflowAssignmentCompletionReasonInternal CompletionReason { get; }
    public UtcDateTime<ApprovalWorkflowAssignmentInternal> CompletedDate { get; }
    public string? CompletionComment { get; }
    public ApprovalWorkflowAssignmentDelegationDetailsInternal? DelegationDetails { get; }
}
