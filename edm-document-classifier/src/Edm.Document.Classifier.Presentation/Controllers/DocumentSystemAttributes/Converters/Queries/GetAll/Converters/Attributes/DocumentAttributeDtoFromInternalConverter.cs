using Edm.Document.Classifier.Application;
using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes;
using Edm.Document.Classifier.Application.DocumentSystemAttributes.Queries.GetAll.Contracts.SystemAttributes.Inheritors;
using Edm.Document.Classifier.GenericSubdomain.Exceptions;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll.Converters.Attributes.Data;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes.Converters.Queries.GetAll.Converters.Attributes;

internal static class DocumentAttributeDtoFromInternalConverter
{
    internal static DocumentSystemAttributeDto FromInternal(DocumentSystemAttributeInternal attribute)
    {
        DocumentSystemAttributeDto result = attribute switch
        {
            AttachmentDocumentSystemAttributeInternal => ToAttachment(),
            BooleanDocumentSystemAttributeInternal => ToBoolean(),
            DateDocumentSystemAttributeInternal => ToDate(),
            NumberDocumentSystemAttributeInternal a => ToNumber(a),
            ReferenceDocumentSystemAttributeInternal a => ToReference(a),
            StringDocumentSystemAttributeInternal => ToString(),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        DocumentSystemAttributeDataDto data = DocumentSystemAttributeDataDtoConverter.FromInternal(attribute.Data);

        result.Data = data;

        return result;
    }

    private static DocumentSystemAttributeDto ToAttachment()
    {
        var asAttachment = new DocumentAttachmentSystemAttributeDto();

        var result = new DocumentSystemAttributeDto
        {
            AsAttachment = asAttachment
        };

        return result;
    }

    private static DocumentSystemAttributeDto ToBoolean()
    {
        var asBoolean = new DocumentBooleanSystemAttributeDto();

        var result = new DocumentSystemAttributeDto
        {
            AsBoolean = asBoolean
        };

        return result;
    }

    private static DocumentSystemAttributeDto ToDate()
    {
        var asDate = new DocumentDateSystemAttributeDto();

        var result = new DocumentSystemAttributeDto
        {
            AsDate = asDate
        };

        return result;
    }

    private static DocumentSystemAttributeDto ToNumber(NumberDocumentSystemAttributeInternal attribute)
    {
        var asNumber = new DocumentNumberSystemAttributeDto
        {
            Precision = attribute.Precision
        };

        var result = new DocumentSystemAttributeDto
        {
            AsNumber = asNumber
        };

        return result;
    }

    private static DocumentSystemAttributeDto ToReference(ReferenceDocumentSystemAttributeInternal attribute)
    {
        string referenceType = ReferenceIdToMetadataConverter.ToMetadata(attribute.ReferenceId);

        var asReference = new DocumentReferenceSystemAttributeDto
        {
            ReferenceType = referenceType
        };

        var result = new DocumentSystemAttributeDto
        {
            AsReference = asReference
        };

        return result;
    }

    private new static DocumentSystemAttributeDto ToString()
    {
        var asString = new DocumentStringSystemAttributeDto();

        var result = new DocumentSystemAttributeDto
        {
            AsString = asString
        };

        return result;
    }
}
