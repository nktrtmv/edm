using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions.Data;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Abstractions.Data;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes;

internal static class DocumentAttributeDbToDomainConverter
{
    internal static DocumentAttribute ToDomain(DocumentAttributeDb attribute)
    {
        DocumentAttributeData data = DocumentAttributeDataDbConverter.ToDomain(attribute.Data);

        DocumentAttribute result = attribute.ValueCase switch
        {
            DocumentAttributeDb.ValueOneofCase.AsAttachment =>
                ToAttachment(data, attribute.AsAttachment),

            DocumentAttributeDb.ValueOneofCase.AsBoolean =>
                ToBoolean(data, attribute.AsBoolean),

            DocumentAttributeDb.ValueOneofCase.AsDate =>
                ToDate(data, attribute.AsDate),

            DocumentAttributeDb.ValueOneofCase.AsNumber =>
                ToNumber(data, attribute.AsNumber),

            DocumentAttributeDb.ValueOneofCase.AsReference =>
                ToReference(data, attribute.AsReference!),

            DocumentAttributeDb.ValueOneofCase.AsString =>
                ToString(data, attribute.AsString),

            DocumentAttributeDb.ValueOneofCase.AsTuple =>
                ToTuple(data, attribute.AsTuple),

            _ => throw new ArgumentTypeOutOfRangeException(attribute.ValueCase)
        };

        return result;
    }

    private static DocumentAttribute ToAttachment(DocumentAttributeData data, DocumentAttachmentAttributeDb attribute)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        DocumentAttribute result = new DocumentAttachmentAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToString(DocumentAttributeData data, DocumentStringAttributeDb attribute)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        DocumentAttribute result = new DocumentStringAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToBoolean(DocumentAttributeData data, DocumentBooleanAttributeDb attribute)
    {
        bool[] defaultValues = attribute.DefaultValues.ToArray();

        DocumentAttribute result = new DocumentBooleanAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToNumber(DocumentAttributeData data, DocumentNumberAttributeDb attribute)
    {
        Number<DocumentNumberAttribute>[] defaultValues = attribute.DefaultValues.Select(NumberConverterFrom<DocumentNumberAttribute>.FromLong).ToArray();

        DocumentAttribute result = new DocumentNumberAttribute(defaultValues, data, attribute.Precision);

        return result;
    }

    private static DocumentAttribute ToDate(DocumentAttributeData data, DocumentDateAttributeDb attribute)
    {
        UtcDateTime<DocumentDateAttribute>[] defaultValues = attribute.DefaultValues.Select(UtcDateTimeConverterFrom<DocumentDateAttribute>.FromTimestamp).ToArray();

        DocumentAttribute result = new DocumentDateAttribute(defaultValues, data);

        return result;
    }

    private static DocumentAttribute ToReference(DocumentAttributeData data, DocumentReferenceAttributeDb attribute)
    {
        string[] defaultValues = attribute.DefaultValues.ToArray();

        Metadata<DocumentReferenceAttribute> referenceType = MetadataConverterFrom<DocumentReferenceAttribute>.FromString(attribute.ReferenceType);

        DocumentAttribute result = new DocumentReferenceAttribute(defaultValues, data, referenceType);

        return result;
    }

    private static DocumentAttribute ToTuple(DocumentAttributeData data, DocumentTupleAttributeDb attribute)
    {
        DocumentAttribute[] innerAttributes = attribute.InnerAttributes.Select(ToDomain).ToArray();

        DocumentAttribute result = new DocumentTupleAttribute(data, innerAttributes);

        return result;
    }
}
