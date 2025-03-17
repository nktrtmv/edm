namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.
    CompletionReasons;

public enum ApprovalWorkflowAssignmentCompletionReasonInternal
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    ReturnedToRework = 3,
    Rejected = 4,
    Delegated = 5,
    CompletedAutomatically = 6
}
