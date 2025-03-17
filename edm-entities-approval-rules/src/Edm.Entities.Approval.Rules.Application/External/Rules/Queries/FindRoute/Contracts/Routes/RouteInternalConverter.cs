using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes;

internal static class RouteInternalConverter
{
    internal static RouteInternal FromDomain(Route route)
    {
        RouteStageInternal[] stages = route.Stages.Select(RouteStageInternalConverter.FromDomain).ToArray();

        var result = new RouteInternal(route.Name, stages, route.UpdatedTime);

        return result;
    }
}
