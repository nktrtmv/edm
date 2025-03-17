using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients.Converters.Queries.FindRoute.Entities.AttributesValues;

internal static class EntitiesApprovalRuleEntityAttributeValueDtoConverter
{
    internal static EntityAttributeValueDto FromExternal(DocumentAttributeValue value)
    {
        EntityAttributeValueDto result = value switch
        {
            BooleanDocumentAttributeValue v => new EntityAttributeValueDto { AsBoolean = ToBoolean(v) },
            DateDocumentAttributeValue v => new EntityAttributeValueDto { AsDate = ToDate(v) },
            NumberDocumentAttributeValue v => new EntityAttributeValueDto { AsNumber = ToNumber(v) },
            ReferenceDocumentAttributeValue v => new EntityAttributeValueDto { AsReference = ToReference(v) },
            StringDocumentAttributeValue v => new EntityAttributeValueDto { AsString = ToString(v) },
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        result.Id = value.Attribute.Data.ApprovalData.MetadataId;

        return result;
    }

    private static EntityBooleanAttributeValueDto ToBoolean(BooleanDocumentAttributeValue attributeValue)
    {
        bool[] value = attributeValue.Values.ToArray();

        var result = new EntityBooleanAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityDateAttributeValueDto ToDate(DateDocumentAttributeValue attributeValue)
    {
        Timestamp[] value = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new EntityDateAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityNumberAttributeValueDto ToNumber(NumberDocumentAttributeValue attributeValue)
    {
        long[] value = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var result = new EntityNumberAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityReferenceAttributeValueDto ToReference(ReferenceDocumentAttributeValue attributeValue)
    {
        string[] value = attributeValue.Values.ToArray();

        var result = new EntityReferenceAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }

    private static EntityStringAttributeValueDto ToString(StringDocumentAttributeValue attributeValue)
    {
        string[] value = attributeValue.Values.ToArray();

        var result = new EntityStringAttributeValueDto
        {
            Value = { value }
        };

        return result;
    }
}
