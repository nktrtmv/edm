using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
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

internal static class EntityTypeAttributeInternalFromDtoConverter
{
    internal static EntityTypeAttributeInternal FromDto(EntityTypeAttributeDto attribute)
    {
        EntityTypeAttributeDataInternal data = EntityTypeAttributeDataInternalConverter.FromDto(attribute.Data);

        EntityTypeAttributeInternal result = attribute.ValueCase switch
        {
            EntityTypeAttributeDto.ValueOneofCase.AsBoolean => new EntityTypeBooleanAttributeInternal(data),
            EntityTypeAttributeDto.ValueOneofCase.AsDate => new EntityTypeDateAttributeInternal(data),
            EntityTypeAttributeDto.ValueOneofCase.AsNumber => ToNumber(data, attribute.AsNumber),
            EntityTypeAttributeDto.ValueOneofCase.AsReference => ToReference(data, attribute.AsReference),
            EntityTypeAttributeDto.ValueOneofCase.AsString => new EntityTypeStringAttributeInternal(data),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    private static EntityTypeNumberAttributeInternal ToNumber(
        EntityTypeAttributeDataInternal data,
        EntityTypeNumberAttributeDto attribute)
    {
        var result = new EntityTypeNumberAttributeInternal(data, attribute.Precision);

        return result;
    }

    private static EntityTypeReferenceAttributeInternal ToReference(
        EntityTypeAttributeDataInternal data,
        EntityTypeReferenceAttributeDto attribute)
    {
        Metadata<EntityTypeReferenceAttributeInternal> referenceTypeId =
            MetadataConverterFrom<EntityTypeReferenceAttributeInternal>.FromString(attribute.ReferenceTypeId);

        var result = new EntityTypeReferenceAttributeInternal(data, referenceTypeId);

        return result;
    }
}
