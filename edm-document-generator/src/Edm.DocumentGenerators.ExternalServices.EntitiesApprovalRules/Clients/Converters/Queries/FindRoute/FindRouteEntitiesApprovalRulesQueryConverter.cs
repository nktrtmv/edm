using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute.Entities;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute;

internal static class FindRouteEntitiesApprovalRulesQueryConverter
{
    internal static FindRouteApprovalRulesQuery FromExternal(
        EntitiesApprovalRuleEntityExternal entity,
        string approvalGraphTag)
    {
        EntityDto? entityDto = EntitiesApprovalRuleEntityDtoConverter.FromExternal(entity);

        var result = new FindRouteApprovalRulesQuery
        {
            Entity = entityDto,
            ApprovalGraphTag = approvalGraphTag
        };

        return result;
    }
}
