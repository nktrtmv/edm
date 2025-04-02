using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;

internal static class FindRouteApprovalRulesQueryInternalConverter
{
    internal static FindRouteQuery ToDomain(FindRouteApprovalRulesQueryInternal request)
    {
        Entity entity = EntityInternalConverter.ToDomain(request.Entity);

        var result = new FindRouteQuery(entity, request.Tag);

        return result;
    }

    internal record struct FindRouteQuery(Entity Entity, string Tag);
}
