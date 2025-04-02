namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Types;

public enum ApprovalRouteStageTypeInternal
{
    None = 0,
    ParallelAny = 1,
    ParallelAll = 2,
    Sequential = 3
}
