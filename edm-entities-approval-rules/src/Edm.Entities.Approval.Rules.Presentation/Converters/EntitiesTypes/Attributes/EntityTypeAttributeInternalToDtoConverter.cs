using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes.Data;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes;

internal static class EntityTypeAttributeInternalToDtoConverter
{
    internal static EntityTypeAttributeDto ToDto(EntityTypeAttributeInternal attribute)
    {
        EntityTypeAttributeDataDto data = EntityTypeAttributeDataInternalConverter.ToDto(attribute.Data);

        EntityTypeAttributeDto result = attribute switch
        {
            EntityTypeBooleanAttributeInternal =>
                new EntityTypeAttributeDto { AsBoolean = new EntityTypeBooleanAttributeDto() },

            EntityTypeDateAttributeInternal =>
                new EntityTypeAttributeDto { AsDate = new EntityTypeDateAttributeDto() },

            EntityTypeNumberAttributeInternal a =>
                new EntityTypeAttributeDto { AsNumber = ToNumber(a) },

            EntityTypeReferenceAttributeInternal a =>
                new EntityTypeAttributeDto { AsReference = ToReference(a) },

            EntityTypeStringAttributeInternal =>
                new EntityTypeAttributeDto { AsString = new EntityTypeStringAttributeDto() },

            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        result.Data = data;

        return result;
    }

    private static EntityTypeNumberAttributeDto ToNumber(EntityTypeNumberAttributeInternal attribute)
    {
        var result = new EntityTypeNumberAttributeDto
        {
            Precision = attribute.Precision
        };

        return result;
    }

    private static EntityTypeReferenceAttributeDto ToReference(EntityTypeReferenceAttributeInternal attribute)
    {
        var referenceTypeId = MetadataConverterTo.ToString(attribute.ReferenceTypeId);

        var result = new EntityTypeReferenceAttributeDto
        {
            ReferenceTypeId = referenceTypeId
        };

        return result;
    }
}
