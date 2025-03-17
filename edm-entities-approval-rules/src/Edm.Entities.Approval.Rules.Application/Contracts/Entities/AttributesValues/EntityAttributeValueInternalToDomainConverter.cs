using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;

internal static class EntityAttributeValueInternalToDomainConverter
{
    internal static EntityAttributeValue ToDomain(EntityAttributeValueInternal attributeValue)
    {
        EntityAttributeValue result = attributeValue switch
        {
            EntityBooleanAttributeValueInternal v => ToBoolean(v),
            EntityDateAttributeValueInternal v => ToDate(v),
            EntityNumberAttributeValueInternal v => ToNumber(v),
            EntityReferenceAttributeValueInternal v => ToReference(v),
            EntityStringAttributeValueInternal v => ToString(v),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static EntityAttributeValue ToBoolean(EntityBooleanAttributeValueInternal attributeValue)
    {
        bool[] value = attributeValue.Value.ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateBooleanFrom(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValue ToDate(EntityDateAttributeValueInternal attributeValue)
    {
        UtcDateTime<EntityDateAttributeValue>[] value =
            attributeValue.Value.Select(UtcDateTimeConverterFrom<EntityDateAttributeValue>.From).ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateDateFrom(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValue ToNumber(EntityNumberAttributeValueInternal attributeValue)
    {
        long[] value = attributeValue.Value.ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateNumberFrom(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValue ToReference(EntityReferenceAttributeValueInternal attributeValue)
    {
        Id<EntityReferenceAttributeValue>[] value =
            attributeValue.Value.Select(IdConverterFrom<EntityReferenceAttributeValue>.From).ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateReferenceFrom(attributeValue.Id, value);

        return result;
    }

    private static EntityAttributeValue ToString(EntityStringAttributeValueInternal attributeValue)
    {
        string[] value = attributeValue.Value.ToArray();

        EntityAttributeValue result = EntityAttributeValueFactory.CreateStringFrom(attributeValue.Id, value);

        return result;
    }
}
