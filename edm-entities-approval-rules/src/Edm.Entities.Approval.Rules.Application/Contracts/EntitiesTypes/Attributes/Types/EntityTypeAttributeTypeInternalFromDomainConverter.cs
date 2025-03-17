using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types;

internal static class EntityTypeAttributeTypeInternalFromDomainConverter
{
    internal static EntityTypeAttributeTypeInternal FromDomain(EntityTypeAttributeType type)
    {
        EntityTypeAttributeTypeInternal result = type switch
        {
            BooleanEntityTypeAttributeType => BooleanEntityTypeAttributeTypeInternal.Instance,
            DateEntityTypeAttributeType => DateEntityTypeAttributeTypeInternal.Instance,
            NumberEntityTypeAttributeType t => ToNumber(t),
            ReferenceEntityTypeAttributeType t => ToReference(t),
            StringEntityTypeAttributeType => StringEntityTypeAttributeTypeInternal.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    private static NumberEntityTypeAttributeTypeInternal ToNumber(NumberEntityTypeAttributeType type)
    {
        var result = new NumberEntityTypeAttributeTypeInternal(type.Precision);

        return result;
    }

    private static ReferenceEntityTypeAttributeTypeInternal ToReference(ReferenceEntityTypeAttributeType type)
    {
        Id<EntityTypeReferenceAttributeInternal> referenceTypeId =
            IdConverterFrom<EntityTypeReferenceAttributeInternal>.From(type.ReferenceTypeId);

        var result = new ReferenceEntityTypeAttributeTypeInternal(referenceTypeId);

        return result;
    }
}
