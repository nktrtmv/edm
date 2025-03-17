using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Types.Mappers;

internal static class RouteStageTypeConverter
{
    internal static RouteStageType FromGraphStageNodeType(ApprovalGraphStageType type)
    {
        RouteStageType result = type switch
        {
            ApprovalGraphStageType.None => RouteStageType.None,
            ApprovalGraphStageType.ParallelAny => RouteStageType.ParallelAny,
            ApprovalGraphStageType.ParallelAll => RouteStageType.ParallelAll,
            ApprovalGraphStageType.Sequential => RouteStageType.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
