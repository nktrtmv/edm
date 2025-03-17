namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Statuses;

public enum ApprovalWorkflowStatusInternal
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Approved = 3,
    Rejected = 4,
    ReturnedToRework = 5,
    ApprovedWithRemark = 6
}
