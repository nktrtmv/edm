namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Statuses;

public enum EntitiesApprovalWorkflowStageStatusExternal
{
    None = 0,
    NotStarted = 1,
    InProgress = 2,
    Approved = 3,
    Rejected = 4,
    ApprovedWithRemark = 5,
    ReturnedToRework = 6
}
