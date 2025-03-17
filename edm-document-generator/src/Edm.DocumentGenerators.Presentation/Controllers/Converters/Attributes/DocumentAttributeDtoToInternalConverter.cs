using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Presentation.Controllers.Converters.Attributes;

internal static class DocumentAttributeDtoToInternalConverter
{
    internal static DocumentAttributeInternal ToInternal(DocumentAttributeDto attribute)
    {
        DocumentAttributeDataInternal data = DocumentAttributeDataDtoConverter.ToInternal(attribute.Data);

        DocumentAttributeInternal result = attribute.ValueCase switch
        {
            DocumentAttributeDto.ValueOneofCase.AsAttachment => ToAttachment(attribute.AsAttachment, data),
            DocumentAttributeDto.ValueOneofCase.AsBoolean => ToBoolean(attribute.AsBoolean, data),
            DocumentAttributeDto.ValueOneofCase.AsDate => ToDate(attribute.AsDate, data),
            DocumentAttributeDto.ValueOneofCase.AsNumber => ToNumber(attribute.AsNumber, data),
            DocumentAttributeDto.ValueOneofCase.AsReference => ToReference(attribute.AsReference, data),
            DocumentAttributeDto.ValueOneofCase.AsString => ToString(attribute.AsString, data),
            DocumentAttributeDto.ValueOneofCase.AsTuple => ToTuple(attribute.AsTuple, data),
            _ => throw new ArgumentTypeOutOfRangeException(attribute.ValueCase)
        };

        return result;
    }

    private static DocumentAttachmentAttributeInternal ToAttachment(DocumentAttachmentAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentAttachmentAttributeInternal(defaultValues, data);

        return result;
    }

    private static DocumentBooleanAttributeInternal ToBoolean(DocumentBooleanAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        bool[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentBooleanAttributeInternal(defaultValues, data);

        return result;
    }

    private static DocumentDateAttributeInternal ToDate(DocumentDateAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        DateTime[] defaultValues = attribute.DefaultValues.Select(v => v.ToDateTime()).ToArray();

        var result = new DocumentDateAttributeInternal(defaultValues, data);

        return result;
    }

    private static DocumentNumberAttributeInternal ToNumber(DocumentNumberAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        long[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentNumberAttributeInternal(defaultValues, data, attribute.Precision);

        return result;
    }

    private static DocumentReferenceAttributeInternal ToReference(DocumentReferenceAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        Metadata<DocumentReferenceAttributeInternal> referenceType = MetadataConverterFrom<DocumentReferenceAttributeInternal>.FromString(attribute.ReferenceType);

        var result = new DocumentReferenceAttributeInternal(defaultValues, data, referenceType);

        return result;
    }

    private static DocumentStringAttributeInternal ToString(DocumentStringAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        var result = new DocumentStringAttributeInternal(defaultValues, data);

        return result;
    }

    private static DocumentTupleAttributeInternal ToTuple(DocumentTupleAttributeDto attribute, DocumentAttributeDataInternal data)
    {
        DocumentAttributeInternal[] innerAttributes = attribute.InnerAttributes.Select(ToInternal).ToArray();

        var result = new DocumentTupleAttributeInternal(data, innerAttributes);

        return result;
    }
}
