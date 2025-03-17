using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType.EntityTypes;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType;

internal static class UpsertEntityTypeEntitiesApprovalRulesCommandConverter
{
    internal static UpsertEntityTypeApprovalRulesCommand FromDomain(EntitiesApprovalRuleEntityTypeExternal entityType, string currentUserId)
    {
        EntityTypeDto entityTypeDto = EntitiesApprovalRuleEntityTypeDtoConverter.FromExternal(entityType);

        var result = new UpsertEntityTypeApprovalRulesCommand
        {
            EntityType = entityTypeDto,
            CurrentUserId = currentUserId
        };

        return result;
    }
}
