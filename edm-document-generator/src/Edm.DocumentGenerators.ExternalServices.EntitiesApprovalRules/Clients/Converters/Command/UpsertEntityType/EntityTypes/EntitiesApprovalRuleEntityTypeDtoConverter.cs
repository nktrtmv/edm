using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType.EntityTypes.Attributes;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Contracts.EntityTypeKeys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities.Types;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Command.UpsertEntityType.EntityTypes;

internal static class EntitiesApprovalRuleEntityTypeDtoConverter
{
    internal static EntityTypeDto FromExternal(EntitiesApprovalRuleEntityTypeExternal entityType)
    {
        EntityTypeKeyDto key =
            EntitiesApprovalRuleEntityTypeKeyDtoConverter.FromExternal(entityType.Key);

        EntityTypeAttributeDto[] attributes =
            entityType.Attributes.Select(EntitiesApprovalRuleEntityTypeAttributeDtoConverter.FromExternal).ToArray();

        var result = new EntityTypeDto
        {
            Key = key,
            Attributes = { attributes },
            DisplayName = entityType.Name
        };

        return result;
    }
}
