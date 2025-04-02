namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;

public enum ApprovalGraphStageType
{
    None = 0,
    ParallelAny = 1,
    ParallelAll = 2,
    Sequential = 3
}
