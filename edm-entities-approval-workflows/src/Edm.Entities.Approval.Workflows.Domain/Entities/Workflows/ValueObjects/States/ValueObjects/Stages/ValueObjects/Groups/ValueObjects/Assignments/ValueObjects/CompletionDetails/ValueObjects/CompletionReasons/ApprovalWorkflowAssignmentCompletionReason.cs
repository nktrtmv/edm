namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.
    CompletionReasons;

public enum ApprovalWorkflowAssignmentCompletionReason
{
    None = 0,
    Approved = 1,
    ApprovedWithRemark = 2,
    Delegated = 3,
    ReturnedToRework = 4,
    Rejected = 5,
    CompletedAutomatically = 6
}
