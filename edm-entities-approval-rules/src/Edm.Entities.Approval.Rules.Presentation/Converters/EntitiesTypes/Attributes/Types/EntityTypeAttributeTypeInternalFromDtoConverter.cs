using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
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

internal static class EntityTypeAttributeTypeInternalFromDtoConverter
{
    internal static EntityTypeAttributeTypeInternal FromDto(EntityTypeAttributeTypeDto type)
    {
        EntityTypeAttributeTypeInternal result = type.TypeCase switch
        {
            EntityTypeAttributeTypeDto.TypeOneofCase.AsBoolean => BooleanEntityTypeAttributeTypeInternal.Instance,
            EntityTypeAttributeTypeDto.TypeOneofCase.AsDate => DateEntityTypeAttributeTypeInternal.Instance,
            EntityTypeAttributeTypeDto.TypeOneofCase.AsNumber => ToNumber(type.AsNumber),
            EntityTypeAttributeTypeDto.TypeOneofCase.AsReference => ToReference(type.AsReference),
            EntityTypeAttributeTypeDto.TypeOneofCase.AsString => StringEntityTypeAttributeTypeInternal.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static NumberEntityTypeAttributeTypeInternal ToNumber(NumberEntityTypeAttributeTypeDto type)
    {
        var result = new NumberEntityTypeAttributeTypeInternal(type.Precision);

        return result;
    }

    private static ReferenceEntityTypeAttributeTypeInternal ToReference(ReferenceEntityTypeAttributeTypeDto type)
    {
        Id<EntityTypeReferenceAttributeInternal> referenceTypeId =
            IdConverterFrom<EntityTypeReferenceAttributeInternal>.FromString(type.ReferenceTypeId);

        var result = new ReferenceEntityTypeAttributeTypeInternal(referenceTypeId);

        return result;
    }
}
