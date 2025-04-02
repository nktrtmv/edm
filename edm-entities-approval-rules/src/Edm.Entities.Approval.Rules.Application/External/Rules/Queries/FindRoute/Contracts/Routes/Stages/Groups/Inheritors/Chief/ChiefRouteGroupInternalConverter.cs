using Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.ValueObjects.Stages.ValueObjects.Groups.Inheritors.Chief;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Routes.Stages.Groups.Inheritors.Chief;

internal static class ChiefRouteGroupInternalConverter
{
    internal static ChiefRouteGroupInternal FromDomain(ChiefRouteGroup group)
    {
        var result = new ChiefRouteGroupInternal(group.Name);

        return result;
    }
}
