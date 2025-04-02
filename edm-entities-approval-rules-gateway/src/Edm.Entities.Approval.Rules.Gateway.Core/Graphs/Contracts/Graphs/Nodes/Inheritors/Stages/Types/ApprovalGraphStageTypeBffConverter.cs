using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;

internal static class ApprovalGraphStageTypeBffConverter
{
    internal static ApprovalGraphStageTypeBff FromDto(ApprovalGraphStageTypeDto type)
    {
        var result = type switch
        {
            ApprovalGraphStageTypeDto.ParallelAny => ApprovalGraphStageTypeBff.ParallelAny,
            ApprovalGraphStageTypeDto.ParallelAll => ApprovalGraphStageTypeBff.ParallelAll,
            ApprovalGraphStageTypeDto.Sequential => ApprovalGraphStageTypeBff.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static ApprovalGraphStageTypeDto ToDto(ApprovalGraphStageTypeBff type)
    {
        var result = type switch
        {
            ApprovalGraphStageTypeBff.ParallelAny => ApprovalGraphStageTypeDto.ParallelAny,
            ApprovalGraphStageTypeBff.ParallelAll => ApprovalGraphStageTypeDto.ParallelAll,
            ApprovalGraphStageTypeBff.Sequential => ApprovalGraphStageTypeDto.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
