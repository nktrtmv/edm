using Edm.DocumentGenerators.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Attachments;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Booleans;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Dates;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Numbers;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.References;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Strings;
using Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues.Inheritors.Tuples;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Commands.Update.Contracts.Bare.AttributesValues;

internal static class DocumentAttributeValueBareBffConverter
{
    public static DocumentAttributeValueDto ToDto(DocumentAttributeValueBareBff attributeValue)
    {
        var result = attributeValue switch
        {
            DocumentAttachmentAttributeValueBareBff v => ToAttachment(v),
            DocumentBooleanAttributeValueBareBff v => ToBoolean(v),
            DocumentDateAttributeValueBareBff v => ToDate(v),
            DocumentNumberAttributeValueBareBff v => ToNumber(v),
            DocumentReferenceAttributeValueBareBff v => ToReference(v),
            DocumentStringAttributeValueBareBff v => ToString(v),
            DocumentTupleAttributeValueBareBff v => ToTuple(v),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        result.AttributeId = attributeValue.Id;

        return result;
    }

    private static DocumentAttributeValueDto ToAttachment(DocumentAttachmentAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var asAttachment = new AttachmentDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsAttachment = asAttachment
        };

        return result;
    }

    private static DocumentAttributeValueDto ToBoolean(DocumentBooleanAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var asBool = new BooleanDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsBoolean = asBool
        };

        return result;
    }

    private static DocumentAttributeValueDto ToDate(DocumentDateAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.Select(v => v.ToTimestamp()).ToArray();

        var asDate = new DateDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsDate = asDate
        };

        return result;
    }

    private static DocumentAttributeValueDto ToNumber(DocumentNumberAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var asNumber = new NumberDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static DocumentAttributeValueDto ToReference(DocumentReferenceAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var asReference = new ReferenceDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsReference = asReference
        };

        return result;
    }

    private static DocumentAttributeValueDto ToString(DocumentStringAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.ToArray();

        var asString = new StringDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsString = asString
        };

        return result;
    }

    private static DocumentAttributeValueDto ToTuple(DocumentTupleAttributeValueBareBff attributeValue)
    {
        var values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var asTuple = new TupleDocumentAttributeValueDto
        {
            Values = { values }
        };

        var result = new DocumentAttributeValueDto
        {
            AsTuple = asTuple
        };

        return result;
    }

    private static TupleInnerValueDocumentAttributeValueDto ToTupleValue(DocumentAttributeValueBareBff[] value)
    {
        var innerValues = value.Select(ToDto).ToArray();

        var result = new TupleInnerValueDocumentAttributeValueDto
        {
            InnerValues = { innerValues }
        };

        return result;
    }
}
