using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Attachment;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Boolean;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Date;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.String;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Tuple;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Attachment;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Boolean;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Date;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.String;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Tuple;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Tuple.InnerValue;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues;

internal static class DocumentAttributeValueExternalFromBareDtoConverter
{
    internal static DocumentAttributeValueExternal FromDto(DocumentAttributeValueDto value)
    {
        var attribute = CreateBareDocumentAttributeExternal(value.ValueCase, value.AttributeId);

        DocumentAttributeValueExternal result = value.ValueCase switch
        {
            DocumentAttributeValueDto.ValueOneofCase.AsBoolean => ToBool(value.AsBoolean, attribute),
            DocumentAttributeValueDto.ValueOneofCase.AsDate => ToDate(value.AsDate, attribute),
            DocumentAttributeValueDto.ValueOneofCase.AsNumber => ToNumber(value.AsNumber, attribute),
            DocumentAttributeValueDto.ValueOneofCase.AsReference => ToReference(value.AsReference, attribute),
            DocumentAttributeValueDto.ValueOneofCase.AsString => ToString(value.AsString, attribute),
            DocumentAttributeValueDto.ValueOneofCase.AsAttachment => ToAttachment(value.AsAttachment, attribute),
            DocumentAttributeValueDto.ValueOneofCase.AsTuple => ToTuple(value.AsTuple, attribute),
            _ => throw new ArgumentTypeOutOfRangeException(value.ValueCase)
        };

        return result;
    }

    private static DocumentBooleanAttributeValueExternal ToBool(BooleanDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        bool[] values = value.Values.ToArray();

        var result = new DocumentBooleanAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentDateAttributeValueExternal ToDate(DateDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        UtcDateTime<DocumentDateAttributeValueExternal>[] values =
            value.Values.Select(UtcDateTimeConverterFrom<DocumentDateAttributeValueExternal>.FromTimestamp).ToArray();

        var result = new DocumentDateAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentNumberAttributeValueExternal ToNumber(NumberDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        Number<DocumentNumberAttributeValueExternal>[] values =
            value.Values.Select(NumberConverterFrom<DocumentNumberAttributeValueExternal>.FromLong).ToArray();

        var result = new DocumentNumberAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentReferenceAttributeValueExternal ToReference(ReferenceDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        string[] values = value.Values.ToArray();

        var result = new DocumentReferenceAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentStringAttributeValueExternal ToString(StringDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        string[] values = value.Values.ToArray();

        var result = new DocumentStringAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentAttachmentAttributeValueExternal ToAttachment(AttachmentDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        string[] values = value.Values.ToArray();

        var result = new DocumentAttachmentAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentTupleAttributeValueExternal ToTuple(
        TupleDocumentAttributeValueDto value, DocumentAttributeExternal attribute)
    {
        DocumentTupleAttributeInnerValueExternal[] values = value.Values.Select(ToTupleValue).ToArray();

        var result = new DocumentTupleAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentTupleAttributeInnerValueExternal ToTupleValue(TupleInnerValueDocumentAttributeValueDto value)
    {
        DocumentAttributeValueExternal[] innerValues = value.InnerValues.Select(FromDto).ToArray();

        var result = new DocumentTupleAttributeInnerValueExternal(innerValues);

        return result;
    }

    private static DocumentAttributeExternal CreateBareDocumentAttributeExternal(DocumentAttributeValueDto.ValueOneofCase valueCase, string attributeId)
    {
        var data = new DocumentAttributeDataExternal(attributeId, false, [], string.Empty, string.Empty, []);

        DocumentAttributeExternal result = valueCase switch
        {
            DocumentAttributeValueDto.ValueOneofCase.AsBoolean => new DocumentBooleanAttributeExternal(data),
            DocumentAttributeValueDto.ValueOneofCase.AsDate => new DocumentDateAttributeExternal(data),
            DocumentAttributeValueDto.ValueOneofCase.AsNumber => new DocumentNumberAttributeExternal(data, 0),
            DocumentAttributeValueDto.ValueOneofCase.AsReference => new DocumentReferenceAttributeExternal(data, string.Empty),
            DocumentAttributeValueDto.ValueOneofCase.AsString => new DocumentStringAttributeExternal(data),
            DocumentAttributeValueDto.ValueOneofCase.AsAttachment => new DocumentAttachmentAttributeExternal(data),
            DocumentAttributeValueDto.ValueOneofCase.AsTuple => new DocumentTupleAttributeExternal(data),
            _ => throw new ArgumentTypeOutOfRangeException(valueCase)
        };

        return result;
    }
}
