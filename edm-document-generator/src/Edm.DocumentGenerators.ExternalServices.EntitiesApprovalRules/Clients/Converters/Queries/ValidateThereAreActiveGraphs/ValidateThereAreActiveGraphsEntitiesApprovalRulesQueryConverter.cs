using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Contracts.EntityTypeKeys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types.Keys;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.ValidateThereAreActiveGraphs;

internal static class ValidateThereAreActiveGraphsEntitiesApprovalRulesQueryConverter
{
    internal static ValidateThereAreActiveGraphsApprovalRulesQuery FromDomain(
        EntitiesApprovalRuleEntityTypeKeyExternal entityTypekey,
        string[] approvalGraphsTags)
    {
        EntityTypeKeyDto entityTypeKeyDto =
            EntitiesApprovalRuleEntityTypeKeyDtoConverter.FromExternal(entityTypekey);

        var result = new ValidateThereAreActiveGraphsApprovalRulesQuery
        {
            EntityTypeKey = entityTypeKeyDto,
            ApprovalGraphsTags = { approvalGraphsTags }
        };

        return result;
    }
}
