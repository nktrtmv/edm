using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Entities.Types;

internal static class EntityTypeInternalConverter
{
    internal static EntityTypeInternal FromDto(EntityTypeDto entityType)
    {
        EntityTypeKeyInternal key = EntityTypeKeyDtoConverter.ToInternal(entityType.Key);

        EntityTypeAttributeInternal[] attributes = entityType.Attributes.Select(EntityTypeAttributeInternalFromDtoConverter.FromDto).ToArray();

        var result = new EntityTypeInternal(key, attributes, entityType.DisplayName);

        return result;
    }
}
