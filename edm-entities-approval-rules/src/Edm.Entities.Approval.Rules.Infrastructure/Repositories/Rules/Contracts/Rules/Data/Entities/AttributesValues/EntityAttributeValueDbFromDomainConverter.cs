using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.AttributesValues;

internal static class EntityAttributeValueDbFromDomainConverter
{
    internal static EntityAttributeValueDb FromDomain(EntityAttributeValue attributeValue)
    {
        EntityAttributeValueDb result = attributeValue switch
        {
            EntityBooleanAttributeValue a => new EntityAttributeValueDb { AsBoolean = ToBoolean(a) },
            EntityDateAttributeValue a => new EntityAttributeValueDb { AsDate = ToDate(a) },
            EntityNumberAttributeValue a => new EntityAttributeValueDb { AsNumber = ToNumber(a) },
            EntityReferenceAttributeValue a => new EntityAttributeValueDb { AsReference = ToReference(a) },
            EntityStringAttributeValue a => new EntityAttributeValueDb { AsString = ToString(a) },

            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        result.Id = attributeValue.Id;

        return result;
    }

    private static EntityBooleanAttributeValueDb ToBoolean(EntityBooleanAttributeValue attributeValue)
    {
        bool[] value = attributeValue.Value.ToArray();

        var result = new EntityBooleanAttributeValueDb
        {
            Value = { value }
        };

        return result;
    }

    private static EntityDateAttributeValueDb ToDate(EntityDateAttributeValue attributeValue)
    {
        Timestamp[] value = attributeValue.Value.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new EntityDateAttributeValueDb
        {
            Value = { value }
        };

        return result;
    }

    private static EntityNumberAttributeValueDb ToNumber(EntityNumberAttributeValue attributeValue)
    {
        long[] value = attributeValue.Value.ToArray();

        var result = new EntityNumberAttributeValueDb
        {
            Value = { value }
        };

        return result;
    }

    private static EntityReferenceAttributeValueDb ToReference(EntityReferenceAttributeValue attributeValue)
    {
        string[] value = attributeValue.Value.Select(IdConverterTo.ToString).ToArray();

        var result = new EntityReferenceAttributeValueDb
        {
            Value = { value }
        };

        return result;
    }

    private static EntityStringAttributeValueDb ToString(EntityStringAttributeValue attributeValue)
    {
        string[] value = attributeValue.Value.ToArray();

        var result = new EntityStringAttributeValueDb
        {
            Value = { value }
        };

        return result;
    }
}
