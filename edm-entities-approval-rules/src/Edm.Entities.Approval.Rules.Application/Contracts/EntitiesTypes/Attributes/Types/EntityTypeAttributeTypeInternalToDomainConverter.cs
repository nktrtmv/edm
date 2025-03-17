using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types;

internal static class EntityTypeAttributeTypeInternalToDomainConverter
{
    internal static EntityTypeAttributeType ToDomain(EntityTypeAttributeTypeInternal type)
    {
        EntityTypeAttributeType result = type switch
        {
            BooleanEntityTypeAttributeTypeInternal => BooleanEntityTypeAttributeType.Instance,
            DateEntityTypeAttributeTypeInternal => DateEntityTypeAttributeType.Instance,
            NumberEntityTypeAttributeTypeInternal t => ToNumber(t),
            ReferenceEntityTypeAttributeTypeInternal t => ToReference(t),
            StringEntityTypeAttributeTypeInternal => StringEntityTypeAttributeType.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static NumberEntityTypeAttributeType ToNumber(NumberEntityTypeAttributeTypeInternal type)
    {
        var result = new NumberEntityTypeAttributeType(type.Precision);

        return result;
    }

    private static ReferenceEntityTypeAttributeType ToReference(ReferenceEntityTypeAttributeTypeInternal type)
    {
        Id<EntityTypeReferenceAttribute> referenceTypeId =
            IdConverterFrom<EntityTypeReferenceAttribute>.From(type.ReferenceTypeId);

        var result = new ReferenceEntityTypeAttributeType(referenceTypeId);

        return result;
    }
}


