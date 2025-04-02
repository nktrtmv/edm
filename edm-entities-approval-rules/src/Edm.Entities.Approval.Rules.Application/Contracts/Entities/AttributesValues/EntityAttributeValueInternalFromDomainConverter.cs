using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;

internal static class EntityAttributeValueInternalFromDomainConverter
{
    internal static EntityAttributeValueInternal FromDomain(EntityAttributeValue attributeValue)
    {
        EntityAttributeValueInternal result = attributeValue switch
        {
            EntityBooleanAttributeValue v => ToBoolean(v),
            EntityDateAttributeValue v => ToDate(v),
            EntityNumberAttributeValue v => ToNumber(v),
            EntityReferenceAttributeValue v => ToReference(v),
            EntityStringAttributeValue v => ToString(v),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static EntityAttributeValueInternal ToBoolean(EntityBooleanAttributeValue attributeValue)
    {
        var result = new EntityBooleanAttributeValueInternal(attributeValue.Id, attributeValue.Value);

        return result;
    }

    private static EntityAttributeValueInternal ToDate(EntityDateAttributeValue attributeValue)
    {
        UtcDateTime<EntityDateAttributeValueInternal>[] value =
            attributeValue.Value.Select(UtcDateTimeConverterFrom<EntityDateAttributeValueInternal>.From).ToArray();

        var result = new EntityDateAttributeValueInternal(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValueInternal ToNumber(EntityNumberAttributeValue attributeValue)
    {
        long[] value = attributeValue.Value.ToArray();

        var result = new EntityNumberAttributeValueInternal(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValueInternal ToReference(EntityReferenceAttributeValue attributeValue)
    {
        Id<EntityReferenceAttributeValueInternal>[] value =
            attributeValue.Value.Select(IdConverterFrom<EntityReferenceAttributeValueInternal>.From).ToArray();

        var result = new EntityReferenceAttributeValueInternal(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValueInternal ToString(EntityStringAttributeValue attributeValue)
    {
        string[] value = attributeValue.Value.ToArray();

        var result = new EntityStringAttributeValueInternal(attributeValue.Id, value);

        return result;
    }
}
