using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Contracts.EntityTypeKeys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute.Entities.AttributesValues;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Contracts.Entities;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute.Entities;

internal static class EntitiesApprovalRuleEntityDtoConverter
{
    internal static EntityDto FromExternal(EntitiesApprovalRuleEntityExternal entity)
    {
        EntityTypeKeyDto typeKey =
            EntitiesApprovalRuleEntityTypeKeyDtoConverter.FromExternal(entity.TypeKey);

        EntityAttributeValueDto[] attributesValues = entity.AttributesValues
            .Where(a => a.Attribute.Data.ApprovalData.IsParticipant)
            .Select(EntitiesApprovalRuleEntityAttributeValueDtoConverter.FromExternal)
            .ToArray();

        var result = new EntityDto
        {
            TypeKey = typeKey,
            AttributesValues = { attributesValues }
        };

        return result;
    }
}
