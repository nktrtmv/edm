using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Types;

internal static class RouteStageTypeInternalConverter
{
    internal static RouteStageTypeInternal FromDomain(RouteStageType type)
    {
        RouteStageTypeInternal result = type switch
        {
            RouteStageType.ParallelAny => RouteStageTypeInternal.ParallelAny,
            RouteStageType.ParallelAll => RouteStageTypeInternal.ParallelAll,
            RouteStageType.Sequential => RouteStageTypeInternal.Sequential,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
