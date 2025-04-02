using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Attachments;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Booleans;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Dates;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Numbers;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.References;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Strings;
using Edm.DocumentGenerators.Application.Contracts.Attributes.Inheritors.Tuples;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;

internal static class DocumentAttributeInternalToDomainConverter
{
    internal static DocumentAttribute ToDomain(DocumentAttributeInternal attribute)
    {
        DocumentAttributeData data = DocumentAttributeDataInternalConverter.ToDomain(attribute.Data);

        DocumentAttribute result = attribute switch
        {
            DocumentAttachmentAttributeInternal a => ToAttachment(data, a),
            DocumentBooleanAttributeInternal a => ToBoolean(data, a),
            DocumentDateAttributeInternal a => ToDate(data, a),
            DocumentNumberAttributeInternal a => ToNumber(data, a),
            DocumentReferenceAttributeInternal a => ToReference(data, a),
            DocumentStringAttributeInternal a => ToString(data, a),
            DocumentTupleAttributeInternal a => ToTuple(data, a.InnerAttributes),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    private static DocumentAttribute ToAttachment(DocumentAttributeData data, DocumentAttachmentAttributeInternal attribute)
    {
        string[] defaultValues = attribute.DefaultValues;

        DocumentAttribute result = new DocumentAttachmentAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToBoolean(DocumentAttributeData data, DocumentBooleanAttributeInternal attribute)
    {
        bool[] defaultValues = attribute.DefaultValues;

        DocumentAttribute result = new DocumentBooleanAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToDate(DocumentAttributeData data, DocumentDateAttributeInternal attribute)
    {
        UtcDateTime<DocumentDateAttribute>[] defaultValues = attribute.DefaultValues.Select(UtcDateTimeConverterFrom<DocumentDateAttribute>.FromUtcDateTime).ToArray();

        DocumentAttribute result = new DocumentDateAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToNumber(DocumentAttributeData data, DocumentNumberAttributeInternal attribute)
    {
        Number<DocumentNumberAttribute>[] defaultValues = attribute.DefaultValues.Select(NumberConverterFrom<DocumentNumberAttribute>.FromLong).ToArray();

        DocumentAttribute result = new DocumentNumberAttribute(defaultValues, data, attribute.Precision);

        return result;
    }

    private static DocumentAttribute ToReference(DocumentAttributeData data, DocumentReferenceAttributeInternal attribute)
    {
        string[] defaultValues = attribute.DefaultValues;

        Metadata<DocumentReferenceAttribute> referenceType = MetadataConverterFrom<DocumentReferenceAttribute>.From(attribute.ReferenceType);

        DocumentAttribute result = new DocumentReferenceAttribute(defaultValues, data, referenceType);

        return result;
    }

    private static DocumentAttribute ToString(DocumentAttributeData data, DocumentStringAttributeInternal attribute)
    {
        string[] defaultValues = attribute.DefaultValues;

        DocumentAttribute result = new DocumentStringAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToTuple(DocumentAttributeData data, DocumentAttributeInternal[] internalInnerAttributes)
    {
        DocumentAttribute[] innerAttributes = internalInnerAttributes.Select(ToDomain).ToArray();

        DocumentAttribute result = new DocumentTupleAttribute(data, innerAttributes);

        return result;
    }
}
