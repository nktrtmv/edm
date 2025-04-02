using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Chief;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Chief;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups;

internal static class RouteGroupInternalConverter
{
    internal static RouteGroupInternal FromDomain(RouteGroup group)
    {
        RouteGroupInternal result = group switch
        {
            ChiefRouteGroup g => ChiefRouteGroupInternalConverter.FromDomain(g),
            DomesticRouteGroup g => DomesticRouteGroupInternalConverter.FromDomain(g),
            _ => throw new ArgumentTypeOutOfRangeException(group)
        };

        return result;
    }
}
