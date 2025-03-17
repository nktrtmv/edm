using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes.Inheritors.Stages.Types;

internal static class ApprovalGraphStageTypeDbConverter
{
    internal static ApprovalGraphStageTypeDb FromDomain(ApprovalGraphStageType type)
    {
        ApprovalGraphStageTypeDb result = type switch
        {
            ApprovalGraphStageType.ParallelAny => ApprovalGraphStageTypeDb.ParallelAny,
            ApprovalGraphStageType.ParallelAll => ApprovalGraphStageTypeDb.ParallelAll,
            ApprovalGraphStageType.Sequential => ApprovalGraphStageTypeDb.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static ApprovalGraphStageType ToDomain(ApprovalGraphStageTypeDb type)
    {
        ApprovalGraphStageType result = type switch
        {
            ApprovalGraphStageTypeDb.ParallelAny => ApprovalGraphStageType.ParallelAny,
            ApprovalGraphStageTypeDb.ParallelAll => ApprovalGraphStageType.ParallelAll,
            ApprovalGraphStageTypeDb.Sequential => ApprovalGraphStageType.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
