namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Statuses;

public enum ApprovalWorkflowStageStatusInternal
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Approved = 3,
    Rejected = 4,
    ApprovedWithRemark = 5,
    ReturnedToRework = 6
}
