using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues.Attributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Boolean;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Date;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues;

internal static class DocumentAttributeValueExternalFromDtoConverter
{
    internal static DocumentAttributeValueExternal FromDto(DocumentAttributeValueDetailedDto value)
    {
        DocumentAttributeExternal attribute = DocumentAttributeExternalFromDtoConverter.FromDto(value.Attribute);

        DocumentAttributeValueExternal result = value.ValueCase switch
        {
            DocumentAttributeValueDetailedDto.ValueOneofCase.AsBoolean => ToBool(value.AsBoolean, attribute),
            DocumentAttributeValueDetailedDto.ValueOneofCase.AsDate => ToDate(value.AsDate, attribute),
            DocumentAttributeValueDetailedDto.ValueOneofCase.AsNumber => ToNumber(value.AsNumber, attribute),
            DocumentAttributeValueDetailedDto.ValueOneofCase.AsReference => ToReference(value.AsReference, attribute),
            DocumentAttributeValueDetailedDto.ValueOneofCase.AsString => ToString(value.AsString, attribute),
            _ => throw new ArgumentTypeOutOfRangeException(value.ValueCase)
        };

        return result;
    }

    private static DocumentBooleanAttributeValueExternal ToBool(DocumentBooleanAttributeValueDetailedDto value, DocumentAttributeExternal attribute)
    {
        bool[] values = value.Values.ToArray();

        var result = new DocumentBooleanAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentDateAttributeValueExternal ToDate(DocumentDateAttributeValueDetailedDto value, DocumentAttributeExternal attribute)
    {
        UtcDateTime<DocumentDateAttributeValueExternal>[] values =
            value.Values.Select(UtcDateTimeConverterFrom<DocumentDateAttributeValueExternal>.FromTimestamp).ToArray();

        var result = new DocumentDateAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentNumberAttributeValueExternal ToNumber(DocumentNumberAttributeValueDetailedDto value, DocumentAttributeExternal attribute)
    {
        Number<DocumentNumberAttributeValueExternal>[] values =
            value.Values.Select(NumberConverterFrom<DocumentNumberAttributeValueExternal>.FromLong).ToArray();

        var result = new DocumentNumberAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentReferenceAttributeValueExternal ToReference(
        DocumentReferenceAttributeValueDetailedDto value,
        DocumentAttributeExternal attribute)
    {
        string[] values = value.Values.ToArray();

        var result = new DocumentReferenceAttributeValueExternal(attribute, values);

        return result;
    }

    private static DocumentStringAttributeValueExternal ToString(DocumentStringAttributeValueDetailedDto value, DocumentAttributeExternal attribute)
    {
        string[] values = value.Values.ToArray();

        var result = new DocumentStringAttributeValueExternal(attribute, values);

        return result;
    }
}
