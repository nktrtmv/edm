namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Types;

public enum ApprovalWorkflowStageTypeInternal
{
    None = 0,
    ParallelAny = 1,
    ParallelAll = 2,
    Sequential = 3
}
