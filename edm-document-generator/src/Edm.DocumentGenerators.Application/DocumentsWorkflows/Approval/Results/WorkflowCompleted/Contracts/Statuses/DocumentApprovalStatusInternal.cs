namespace Edm.DocumentGenerators.Application.DocumentsWorkflows.Approval.Results.WorkflowCompleted.Contracts.Statuses;

public enum DocumentApprovalStatusInternal
{
    None = 0,
    Approved = 1,
    Cancelled = 2,
    ApprovedWithRemark = 3,
    ReturnedToRework = 4
}
