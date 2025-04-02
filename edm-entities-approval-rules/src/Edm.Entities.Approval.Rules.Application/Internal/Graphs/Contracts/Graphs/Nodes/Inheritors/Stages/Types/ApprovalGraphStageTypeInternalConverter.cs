using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;

internal static class ApprovalGraphStageTypeInternalConverter
{
    internal static ApprovalGraphStageTypeInternal FromDomain(ApprovalGraphStageType type)
    {
        ApprovalGraphStageTypeInternal result = type switch
        {
            ApprovalGraphStageType.ParallelAny => ApprovalGraphStageTypeInternal.ParallelAny,
            ApprovalGraphStageType.ParallelAll => ApprovalGraphStageTypeInternal.ParallelAll,
            ApprovalGraphStageType.Sequential => ApprovalGraphStageTypeInternal.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static ApprovalGraphStageType ToDomain(ApprovalGraphStageTypeInternal type)
    {
        ApprovalGraphStageType result = type switch
        {
            ApprovalGraphStageTypeInternal.ParallelAny => ApprovalGraphStageType.ParallelAny,
            ApprovalGraphStageTypeInternal.ParallelAll => ApprovalGraphStageType.ParallelAll,
            ApprovalGraphStageTypeInternal.Sequential => ApprovalGraphStageType.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
