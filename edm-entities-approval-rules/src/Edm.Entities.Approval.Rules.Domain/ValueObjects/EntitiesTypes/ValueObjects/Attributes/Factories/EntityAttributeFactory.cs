using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Factories;

public static class EntityAttributeFactory
{
    public static EntityTypeAttribute CreateFrom<T>(EntityTypeAttributeData data)
        where T : EntityTypeAttribute
    {
        if (typeof(T) == typeof(EntityTypeBooleanAttribute))
        {
            return new EntityTypeBooleanAttribute(data);
        }

        if (typeof(T) == typeof(EntityTypeDateAttribute))
        {
            return new EntityTypeDateAttribute(data);
        }

        if (typeof(T) == typeof(EntityTypeStringAttribute))
        {
            return new EntityTypeStringAttribute(data);
        }

        throw new ArgumentTypeOutOfRangeException(data);
    }

    public static EntityTypeAttribute CreateNumberFrom(EntityTypeAttributeData data, int precision = 0)
    {
        var result = new EntityTypeNumberAttribute(data, precision);

        return result;
    }

    public static EntityTypeAttribute CreateReferenceFrom(EntityTypeAttributeData data, Metadata<EntityTypeReferenceAttribute> referenceTypeId)
    {
        var result = new EntityTypeReferenceAttribute(data, referenceTypeId);

        return result;
    }
}
