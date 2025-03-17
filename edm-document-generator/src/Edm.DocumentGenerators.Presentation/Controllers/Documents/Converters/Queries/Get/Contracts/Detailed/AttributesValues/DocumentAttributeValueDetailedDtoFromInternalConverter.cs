using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Attachments;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Booleans;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Dates;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Numbers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.References;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Strings;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Presentation.Controllers.Documents.Converters.Queries.Get.Contracts.Detailed.AttributesValues;

internal static class DocumentAttributeValueDetailedDtoFromInternalConverter
{
    internal static DocumentAttributeValueDetailedDto FromInternal(DocumentAttributeValueDetailedInternal attributeValue)
    {
        DocumentAttributeValueDetailedDto result = attributeValue switch
        {
            DocumentAttachmentAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsAttachment = ToAttachment(v) },
            DocumentBooleanAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsBoolean = ToBoolean(v) },
            DocumentDateAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsDate = ToDate(v) },
            DocumentNumberAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsNumber = ToNumber(v) },
            DocumentReferenceAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsReference = ToReference(v) },
            DocumentStringAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsString = ToString(v) },
            DocumentTupleAttributeValueDetailedInternal v => new DocumentAttributeValueDetailedDto { AsTuple = ToTuple(v) },
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        DocumentAttributeDto attribute = DocumentAttributeDtoFromInternalConverter.FromInternal(attributeValue.Attribute);

        result.Attribute = attribute;

        return result;
    }

    private static DocumentAttachmentAttributeValueDetailedDto ToAttachment(DocumentAttachmentAttributeValueDetailedInternal attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new DocumentAttachmentAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentBooleanAttributeValueDetailedDto ToBoolean(DocumentBooleanAttributeValueDetailedInternal attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new DocumentBooleanAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentDateAttributeValueDetailedDto ToDate(DocumentDateAttributeValueDetailedInternal attributeValue)
    {
        Timestamp[] values = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new DocumentDateAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentNumberAttributeValueDetailedDto ToNumber(DocumentNumberAttributeValueDetailedInternal attributeValue)
    {
        long[] values = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var result = new DocumentNumberAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentReferenceAttributeValueDetailedDto ToReference(DocumentReferenceAttributeValueDetailedInternal attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new DocumentReferenceAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentStringAttributeValueDetailedDto ToString(DocumentStringAttributeValueDetailedInternal attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new DocumentStringAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentTupleAttributeValueDetailedDto ToTuple(DocumentTupleAttributeValueDetailedInternal attributeValue)
    {
        DocumentTupleAttributeValueInnerValueDetailedDto[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new DocumentTupleAttributeValueDetailedDto
        {
            Values = { values }
        };

        return result;
    }

    private static DocumentTupleAttributeValueInnerValueDetailedDto ToTupleValue(DocumentTupleAttributeValueInnerValueDetailedInternal value)
    {
        DocumentAttributeValueDetailedDto[] innerValues = value.InnerValues.Select(FromInternal).ToArray();

        var result = new DocumentTupleAttributeValueInnerValueDetailedDto
        {
            InnerValues = { innerValues }
        };

        return result;
    }
}
