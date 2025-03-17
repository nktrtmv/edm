using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;

internal static class EntityTypeAttributeInternalFromDomainConverter
{
    internal static EntityTypeAttributeInternal FromDomain(EntityTypeAttribute attribute)
    {
        EntityTypeAttributeDataInternal data = EntityTypeAttributeDataInternalConverter.FromDomain(attribute.Data);

        EntityTypeAttributeInternal result = attribute switch
        {
            EntityTypeBooleanAttribute => ToBoolean(data),
            EntityTypeDateAttribute => ToDate(data),
            EntityTypeNumberAttribute a => ToNumber(data, a),
            EntityTypeReferenceAttribute a => ToReference(data, a),
            EntityTypeStringAttribute => ToString(data),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    private static EntityTypeBooleanAttributeInternal ToBoolean(EntityTypeAttributeDataInternal data)
    {
        return new EntityTypeBooleanAttributeInternal(data);
    }

    private static EntityTypeDateAttributeInternal ToDate(EntityTypeAttributeDataInternal data)
    {
        return new EntityTypeDateAttributeInternal(data);
    }

    private static EntityTypeNumberAttributeInternal ToNumber(EntityTypeAttributeDataInternal data, EntityTypeNumberAttribute attribute)
    {
        return new EntityTypeNumberAttributeInternal(data, attribute.Precision);
    }

    private static EntityTypeReferenceAttributeInternal ToReference(EntityTypeAttributeDataInternal data, EntityTypeReferenceAttribute attribute)
    {
        Metadata<EntityTypeReferenceAttributeInternal> referenceType =
            MetadataConverterFrom<EntityTypeReferenceAttributeInternal>.From(attribute.ReferenceTypeId);

        return new EntityTypeReferenceAttributeInternal(data, referenceType);
    }

    private static EntityTypeStringAttributeInternal ToString(EntityTypeAttributeDataInternal data)
    {
        return new EntityTypeStringAttributeInternal(data);
    }
}
