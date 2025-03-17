using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Entities;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Converters;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Entities;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Queries.FindRoute;

internal static class FindRouteApprovalRulesQueryInternalConverter
{
    internal static FindRouteApprovalRulesQueryInternal FromDto(FindRouteApprovalRulesQuery query)
    {
        EntityInternal entity = EntityInternalConverter.FromDto(query.Entity);

        var result = new FindRouteApprovalRulesQueryInternal(entity, query.ApprovalGraphTag);

        return result;
    }
}
