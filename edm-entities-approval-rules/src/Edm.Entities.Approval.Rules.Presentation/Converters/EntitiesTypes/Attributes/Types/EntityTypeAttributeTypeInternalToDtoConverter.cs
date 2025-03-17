using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.EntitiesTypes.Attributes.Types;

internal static class EntityTypeAttributeTypeInternalToDtoConverter
{
    internal static EntityTypeAttributeTypeDto ToDto(EntityTypeAttributeTypeInternal type)
    {
        EntityTypeAttributeTypeDto result = type switch
        {
            BooleanEntityTypeAttributeTypeInternal => ToBoolean(),
            DateEntityTypeAttributeTypeInternal => ToDate(),
            NumberEntityTypeAttributeTypeInternal t => ToNumber(t),
            ReferenceEntityTypeAttributeTypeInternal t => ToReference(t),
            StringEntityTypeAttributeTypeInternal => ToString(),
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static EntityTypeAttributeTypeDto ToBoolean()
    {
        var asBoolean = new BooleanEntityTypeAttributeTypeDto();

        var result = new EntityTypeAttributeTypeDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static EntityTypeAttributeTypeDto ToDate()
    {
        var asDate = new DateEntityTypeAttributeTypeDto();

        var result = new EntityTypeAttributeTypeDto
        {
            AsDate = asDate
        };

        return result;
    }

    private static EntityTypeAttributeTypeDto ToNumber(NumberEntityTypeAttributeTypeInternal type)
    {
        var asNumber = new NumberEntityTypeAttributeTypeDto
        {
            Precision = type.Precision
        };

        var result = new EntityTypeAttributeTypeDto
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static EntityTypeAttributeTypeDto ToReference(ReferenceEntityTypeAttributeTypeInternal type)
    {
        var referenceTypeId = IdConverterTo.ToString(type.ReferenceTypeId);

        var asReference = new ReferenceEntityTypeAttributeTypeDto
        {
            ReferenceTypeId = referenceTypeId
        };

        var result = new EntityTypeAttributeTypeDto
        {
            AsReference = asReference
        };

        return result;
    }

    private new static EntityTypeAttributeTypeDto ToString()
    {
        var asString = new StringEntityTypeAttributeTypeDto();

        var result = new EntityTypeAttributeTypeDto
        {
            AsString = asString
        };

        return result;
    }
}
