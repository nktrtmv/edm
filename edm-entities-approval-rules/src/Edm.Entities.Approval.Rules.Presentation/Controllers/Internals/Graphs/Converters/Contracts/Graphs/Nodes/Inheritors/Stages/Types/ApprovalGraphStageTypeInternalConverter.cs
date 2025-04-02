using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes.Inheritors.Stages.Types;

internal static class ApprovalGraphStageTypeInternalConverter
{
    internal static ApprovalGraphStageTypeDto ToDto(ApprovalGraphStageTypeInternal type)
    {
        ApprovalGraphStageTypeDto result = type switch
        {
            ApprovalGraphStageTypeInternal.ParallelAny => ApprovalGraphStageTypeDto.ParallelAny,
            ApprovalGraphStageTypeInternal.ParallelAll => ApprovalGraphStageTypeDto.ParallelAll,
            ApprovalGraphStageTypeInternal.Sequential => ApprovalGraphStageTypeDto.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static ApprovalGraphStageTypeInternal FromDto(ApprovalGraphStageTypeDto type)
    {
        ApprovalGraphStageTypeInternal result = type switch
        {
            ApprovalGraphStageTypeDto.ParallelAny => ApprovalGraphStageTypeInternal.ParallelAny,
            ApprovalGraphStageTypeDto.ParallelAll => ApprovalGraphStageTypeInternal.ParallelAll,
            ApprovalGraphStageTypeDto.Sequential => ApprovalGraphStageTypeInternal.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
