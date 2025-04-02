using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Routes;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute.Routes;

internal static class EntitiesApprovalRuleRouteDtoConverter
{
    internal static EntitiesApprovalRuleRouteExternal ToExternal(FindRouteApprovalRulesQueryResponse response)
    {
        Bytes<EntitiesApprovalRuleRouteExternal> findRouteResponse =
            BytesConverterFrom<EntitiesApprovalRuleRouteExternal>.FromDto(response);

        var result = new EntitiesApprovalRuleRouteExternal(findRouteResponse);

        return result;
    }
}
