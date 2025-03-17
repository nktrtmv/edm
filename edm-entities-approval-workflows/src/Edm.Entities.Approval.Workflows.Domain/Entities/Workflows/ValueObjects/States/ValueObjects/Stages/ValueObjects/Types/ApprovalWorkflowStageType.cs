namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Types;

public enum ApprovalWorkflowStageType
{
    None = 0,
    ParallelAny = 1,
    ParallelAll = 2,
    Sequential = 3
}
