using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;

internal static class EntityTypeInternalConverter
{
    internal static EntityType ToDomain(EntityTypeInternal type)
    {
        EntityTypeKey key = EntityTypeKeyInternalConverter.ToDomain(type.TypeKey);

        EntityTypeAttribute[] attributes = type.Attributes.Select(EntityTypeAttributeInternalToDomainConverter.ToDomain).ToArray();

        var result = new EntityType(key, attributes, type.DisplayName);

        return result;
    }
}
