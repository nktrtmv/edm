namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;

public enum ApprovalWorkflowStatus
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Approved = 3,
    Rejected = 4,
    ReturnedToRework = 5,
    ApprovedWithRemark = 6
}
