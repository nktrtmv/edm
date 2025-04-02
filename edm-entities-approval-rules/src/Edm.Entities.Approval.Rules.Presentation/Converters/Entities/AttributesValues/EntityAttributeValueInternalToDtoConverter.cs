using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Boolean;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Date;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Number;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Reference;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.String;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Entities.Approval.Rules.Presentation.Converters.Entities.AttributesValues;

internal static class EntityAttributeValueInternalToDtoConverter
{
    internal static EntityAttributeValueDto ToDto(EntityAttributeValueInternal attributeValue)
    {
        EntityAttributeValueDto result = attributeValue switch
        {
            EntityBooleanAttributeValueInternal a => new EntityAttributeValueDto { AsBoolean = ToBoolean(a) },
            EntityDateAttributeValueInternal a => new EntityAttributeValueDto { AsDate = ToDate(a) },
            EntityNumberAttributeValueInternal a => new EntityAttributeValueDto { AsNumber = ToNumber(a) },
            EntityReferenceAttributeValueInternal a => new EntityAttributeValueDto { AsReference = ToReference(a) },
            EntityStringAttributeValueInternal a => new EntityAttributeValueDto { AsString = ToString(a) },
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        result.Id = attributeValue.Id;

        return result;
    }

    private static EntityBooleanAttributeValueDto ToBoolean(EntityBooleanAttributeValueInternal attributeValue)
    {
        bool[] value = attributeValue.Value.ToArray();

        var result = new EntityBooleanAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityDateAttributeValueDto ToDate(EntityDateAttributeValueInternal attributeValue)
    {
        Timestamp[] value = attributeValue.Value.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new EntityDateAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityNumberAttributeValueDto ToNumber(EntityNumberAttributeValueInternal attributeValue)
    {
        long[] value = attributeValue.Value.ToArray();

        var result = new EntityNumberAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityReferenceAttributeValueDto ToReference(EntityReferenceAttributeValueInternal attributeValue)
    {
        string[] value = attributeValue.Value.Select(IdConverterTo.ToString).ToArray();

        var result = new EntityReferenceAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityStringAttributeValueDto ToString(EntityStringAttributeValueInternal attributeValue)
    {
        string[] value = attributeValue.Value.ToArray();

        var result = new EntityStringAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }
}
