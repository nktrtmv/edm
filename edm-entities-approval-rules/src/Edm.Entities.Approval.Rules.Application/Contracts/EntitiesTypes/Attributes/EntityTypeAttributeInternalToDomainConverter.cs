using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;

internal static class EntityTypeAttributeInternalToDomainConverter
{
    internal static EntityTypeAttribute ToDomain(EntityTypeAttributeInternal attribute)
    {
        EntityTypeAttributeData data = EntityTypeAttributeDataInternalConverter.ToDomain(attribute.Data);

        EntityTypeAttribute result = attribute switch
        {
            EntityTypeBooleanAttributeInternal => To<EntityTypeBooleanAttribute>(data),
            EntityTypeDateAttributeInternal => To<EntityTypeDateAttribute>(data),
            EntityTypeNumberAttributeInternal a => ToNumber(data, a),
            EntityTypeReferenceAttributeInternal a => ToReference(data, a),
            EntityTypeStringAttributeInternal => To<EntityTypeStringAttribute>(data),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    private static EntityTypeAttribute To<T>(EntityTypeAttributeData data) where T : EntityTypeAttribute
    {
        EntityTypeAttribute result = EntityAttributeFactory.CreateFrom<T>(data);

        return result;
    }

    private static EntityTypeAttribute ToNumber(EntityTypeAttributeData data, EntityTypeNumberAttributeInternal attribute)
    {
        EntityTypeAttribute result = EntityAttributeFactory.CreateNumberFrom(data, attribute.Precision);

        return result;
    }

    private static EntityTypeAttribute ToReference(EntityTypeAttributeData data, EntityTypeReferenceAttributeInternal attribute)
    {
        Metadata<EntityTypeReferenceAttribute> referenceType = MetadataConverterFrom<EntityTypeReferenceAttribute>.From(attribute.ReferenceTypeId);

        EntityTypeAttribute result = EntityAttributeFactory.CreateReferenceFrom(data, referenceType);

        return result;
    }
}
