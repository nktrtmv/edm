using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues.Attributes.Data;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Abstractions.Data;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Boolean;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Date;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Number;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.Reference;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts.AttributesValues.Abstractions.Attributes.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents.AttributesValues.Attributes;

internal static class DocumentAttributeExternalFromDtoConverter
{
    internal static DocumentAttributeExternal FromDto(DocumentAttributeDto attribute)
    {
        DocumentAttributeDataExternal data = DocumentAttributeDataExternalConverter.FromDto(attribute.Data);

        DocumentAttributeExternal result = attribute.ValueCase switch
        {
            DocumentAttributeDto.ValueOneofCase.AsBoolean => ToBool(data),

            DocumentAttributeDto.ValueOneofCase.AsDate => ToDate(data),

            DocumentAttributeDto.ValueOneofCase.AsNumber => ToNumber(attribute.AsNumber, data),

            DocumentAttributeDto.ValueOneofCase.AsReference => ToReference(attribute.AsReference, data),

            DocumentAttributeDto.ValueOneofCase.AsString => ToString(data),

            _ => throw new ArgumentTypeOutOfRangeException(attribute.ValueCase)
        };

        return result;
    }

    private static DocumentBooleanAttributeExternal ToBool(DocumentAttributeDataExternal data)
    {
        var result = new DocumentBooleanAttributeExternal(data);

        return result;
    }

    private static DocumentDateAttributeExternal ToDate(DocumentAttributeDataExternal data)
    {
        var result = new DocumentDateAttributeExternal(data);

        return result;
    }

    private static DocumentNumberAttributeExternal ToNumber(DocumentNumberAttributeDto attribute, DocumentAttributeDataExternal data)
    {
        var result = new DocumentNumberAttributeExternal(data, attribute.Precision);

        return result;
    }

    private static DocumentReferenceAttributeExternal ToReference(DocumentReferenceAttributeDto attribute, DocumentAttributeDataExternal data)
    {
        var result = new DocumentReferenceAttributeExternal(data, attribute.ReferenceType);

        return result;
    }

    private static DocumentStringAttributeExternal ToString(DocumentAttributeDataExternal data)
    {
        var result = new DocumentStringAttributeExternal(data);

        return result;
    }
}
