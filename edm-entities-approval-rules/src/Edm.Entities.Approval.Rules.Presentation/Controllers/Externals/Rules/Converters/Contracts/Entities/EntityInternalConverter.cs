using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Contracts.Entities;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Converters;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;
using Edm.Entities.Approval.Rules.Presentation.Converters.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules.Converters.Contracts.Entities;

internal static class EntityInternalConverter
{
    internal static EntityInternal FromDto(EntityDto entity)
    {
        EntityTypeKeyInternal typeKey = EntityTypeKeyDtoConverter.ToInternal(entity.TypeKey);

        EntityAttributeValueInternal[] attributesValues =
            entity.AttributesValues.Select(EntityAttributeValueInternalFromDtoConverter.FromDto).ToArray();

        var result = new EntityInternal(typeKey, attributesValues);

        return result;
    }
}
