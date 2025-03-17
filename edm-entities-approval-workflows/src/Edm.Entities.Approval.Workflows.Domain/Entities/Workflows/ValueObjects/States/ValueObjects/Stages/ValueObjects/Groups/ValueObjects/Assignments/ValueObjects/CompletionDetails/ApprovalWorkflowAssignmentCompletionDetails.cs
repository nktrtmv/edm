using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails;

public sealed class ApprovalWorkflowAssignmentCompletionDetails
{
    internal ApprovalWorkflowAssignmentCompletionDetails(
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        UtcDateTime<ApprovalWorkflowAssignment> completedDate,
        string? completionComment,
        ApprovalWorkflowAssignmentDelegationDetails? delegationDetails)
    {
        CompletionReason = completionReason;
        CompletedDate = completedDate;
        CompletionComment = completionComment;
        DelegationDetails = delegationDetails;
    }

    public ApprovalWorkflowAssignmentCompletionReason CompletionReason { get; }
    public UtcDateTime<ApprovalWorkflowAssignment> CompletedDate { get; }
    public string? CompletionComment { get; }
    public ApprovalWorkflowAssignmentDelegationDetails? DelegationDetails { get; private set; }

    public override string ToString()
    {
        return
            $"{{ CompletedDate: {CompletedDate}, CompletionComment: {CompletionComment}, DelegationDetails: {DelegationDetails} }}";
    }
}
