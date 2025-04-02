using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

internal static class DocumentAttributeInternalFromDomainConverter
{
    internal static DocumentAttributeInternal FromDomain(DocumentAttribute attribute)
    {
        DocumentAttributeDataInternal data = DocumentAttributeDataInternalConverter.FromDomain(attribute.Data);

        DocumentAttributeInternal result = attribute switch
        {
            DocumentAttachmentAttribute a => ToAttachment(data, a),
            DocumentBooleanAttribute a => ToBoolean(data, a),
            DocumentDateAttribute a => ToDate(data, a),
            DocumentNumberAttribute a => ToNumber(data, a),
            DocumentReferenceAttribute a => ToReference(data, a),
            DocumentStringAttribute a => ToString(data, a),
            DocumentTupleAttribute a => ToTuple(data, a.InnerAttributes),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    private static DocumentAttachmentAttributeInternal ToAttachment(DocumentAttributeDataInternal data, DocumentAttachmentAttribute attribute)
    {
        var result = new DocumentAttachmentAttributeInternal(attribute.DefaultValues, data);

        return result;
    }

    private static DocumentBooleanAttributeInternal ToBoolean(DocumentAttributeDataInternal data, DocumentBooleanAttribute attribute)
    {
        var result = new DocumentBooleanAttributeInternal(attribute.DefaultValues, data);

        return result;
    }

    private static DocumentDateAttributeInternal ToDate(DocumentAttributeDataInternal data, DocumentDateAttribute attribute)
    {
        DateTime[] defaultValues = attribute.DefaultValues.Select(UtcDateTimeConverterTo.ToDateTime).ToArray();

        var result = new DocumentDateAttributeInternal(defaultValues, data);

        return result;
    }

    private static DocumentNumberAttributeInternal ToNumber(DocumentAttributeDataInternal data, DocumentNumberAttribute attribute)
    {
        long[] defaultValues = attribute.DefaultValues.Select(NumberConverterTo.ToLong).ToArray();

        var result = new DocumentNumberAttributeInternal(defaultValues, data, attribute.Precision);

        return result;
    }

    private static DocumentReferenceAttributeInternal ToReference(DocumentAttributeDataInternal data, DocumentReferenceAttribute attribute)
    {
        Metadata<DocumentReferenceAttributeInternal> referenceType = MetadataConverterFrom<DocumentReferenceAttributeInternal>.From(attribute.ReferenceType);

        var result = new DocumentReferenceAttributeInternal(attribute.DefaultValues, data, referenceType);

        return result;
    }

    private static DocumentStringAttributeInternal ToString(DocumentAttributeDataInternal data, DocumentStringAttribute attribute)
    {
        var result = new DocumentStringAttributeInternal(attribute.DefaultValues, data);

        return result;
    }

    private static DocumentTupleAttributeInternal ToTuple(DocumentAttributeDataInternal data, DocumentAttribute[] innerAttributes)
    {
        DocumentAttributeInternal[] internalInnerAttributes = innerAttributes.Select(FromDomain).ToArray();

        var result = new DocumentTupleAttributeInternal(data, internalInnerAttributes);

        return result;
    }
}
