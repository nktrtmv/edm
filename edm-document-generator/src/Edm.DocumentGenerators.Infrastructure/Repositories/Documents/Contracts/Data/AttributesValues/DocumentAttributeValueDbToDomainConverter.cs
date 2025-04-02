using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes;
using Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.AttributesValues.Abstractions.Data;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.AttributesValues;

internal static class DocumentAttributeValueDbToDomainConverter
{
    internal static DocumentAttributeValue ToDomain(DocumentAttributeValueDb attributeValue)
    {
        if (attributeValue.Attribute is null) // TODO: REMOVE: This is for backward compatibility, remove in version 2.
        {
            return ObsoleteDocumentAttributeValueDbToDomainConverter.ToDomainObsolete(attributeValue);
        }

        DocumentAttribute attribute = DocumentAttributeDbToDomainConverter.ToDomain(attributeValue.Attribute);

        DocumentAttributeValue result = attributeValue.ValueCase switch
        {
            DocumentAttributeValueDb.ValueOneofCase.AsAttachment => ToAttachment(attribute, attributeValue.AsAttachment),
            DocumentAttributeValueDb.ValueOneofCase.AsBoolean => ToBoolean(attribute, attributeValue.AsBoolean),
            DocumentAttributeValueDb.ValueOneofCase.AsDate => ToDate(attribute, attributeValue.AsDate),
            DocumentAttributeValueDb.ValueOneofCase.AsInt => ToNumber(
                attribute,
                attributeValue.AsInt), // TODO: REMOVE: This is for backward compatibility, remove in version 2.
            DocumentAttributeValueDb.ValueOneofCase.AsNumber => ToNumber(attribute, attributeValue.AsNumber),
            DocumentAttributeValueDb.ValueOneofCase.AsReference => ToReference(attribute, attributeValue.AsReference),
            DocumentAttributeValueDb.ValueOneofCase.AsString => ToString(attribute, attributeValue.AsString),
            DocumentAttributeValueDb.ValueOneofCase.AsTuple => ToTuple(attribute, attributeValue.AsTuple),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue.ValueCase)
        };

        return result;
    }

    private static AttachmentDocumentAttributeValue ToAttachment(DocumentAttribute attribute, AttachmentDocumentAttributeValueDb attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new AttachmentDocumentAttributeValue(attribute, values);

        return result;
    }

    private static BooleanDocumentAttributeValue ToBoolean(DocumentAttribute attribute, BooleanDocumentAttributeValueDb attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAttributeValue(attribute, values);

        return result;
    }

    private static DateDocumentAttributeValue ToDate(DocumentAttribute attribute, DateDocumentAttributeValueDb attributeValue)
    {
        UtcDateTime<DateDocumentAttributeValue>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAttributeValue>.FromTimestamp).ToArray();

        var result = new DateDocumentAttributeValue(attribute, values);

        return result;
    }

    private static NumberDocumentAttributeValue ToNumber(DocumentAttribute attribute, IntDocumentAttributeValueDb attributeValue)
    {
        Number<NumberDocumentAttributeValue>[] values =
            attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValue>.FromInt).ToArray();

        var result = new NumberDocumentAttributeValue(attribute, values);

        return result;
    }

    private static NumberDocumentAttributeValue ToNumber(DocumentAttribute attribute, NumberDocumentAttributeValueDb attributeValue)
    {
        Number<NumberDocumentAttributeValue>[] values =
            attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValue>.FromLong).ToArray();

        var result = new NumberDocumentAttributeValue(attribute, values);

        return result;
    }

    private static ReferenceDocumentAttributeValue ToReference(DocumentAttribute attribute, ReferenceDocumentAttributeValueDb attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAttributeValue(attribute, values);

        return result;
    }

    private static StringDocumentAttributeValue ToString(DocumentAttribute attribute, StringDocumentAttributeValueDb attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAttributeValue(attribute, values);

        return result;
    }

    private static TupleDocumentAttributeValue ToTuple(DocumentAttribute attribute, TupleDocumentAttributeValueDb attributeValue)
    {
        TupleInnerValueDocumentAttributeValue[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAttributeValue(attribute, values);

        return result;
    }

    private static TupleInnerValueDocumentAttributeValue ToTupleValue(TupleInnerDocumentAttributeValueDb value)
    {
        DocumentAttributeValue[] innerValues = value.InnerValues.Select(ToDomain).ToArray();

        var result = new TupleInnerValueDocumentAttributeValue(innerValues);

        return result;
    }

    // TODO: REMOVE: This is for backward compatibility, remove in version 2.
    private static class ObsoleteDocumentAttributeValueDbToDomainConverter
    {
        internal static DocumentAttributeValue ToDomainObsolete(DocumentAttributeValueDb attributeValue)
        {
            DocumentAttributeValue result = attributeValue.ValueCase switch
            {
                DocumentAttributeValueDb.ValueOneofCase.AsAttachment => ToAttachment(attributeValue.AsAttachment),
                DocumentAttributeValueDb.ValueOneofCase.AsBoolean => ToBoolean(attributeValue.AsBoolean),
                DocumentAttributeValueDb.ValueOneofCase.AsDate => ToDate(attributeValue.AsDate),
                DocumentAttributeValueDb.ValueOneofCase.AsInt => ToNumber(
                    attributeValue
                        .AsInt), // TODO: REMOVE: This is for backward compatibility, remove in version 2.
                DocumentAttributeValueDb.ValueOneofCase.AsNumber => ToNumber(attributeValue.AsNumber),
                DocumentAttributeValueDb.ValueOneofCase.AsReference => ToReference(attributeValue.AsReference),
                DocumentAttributeValueDb.ValueOneofCase.AsString => ToString(attributeValue.AsString),
                DocumentAttributeValueDb.ValueOneofCase.AsTuple => ToTuple(attributeValue.AsTuple),
                _ => throw new ArgumentTypeOutOfRangeException(attributeValue.ValueCase)
            };

            return result;
        }

        private static AttachmentDocumentAttributeValue ToAttachment(AttachmentDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            string[] values = attributeValue.Values.ToArray();

            var result = new AttachmentDocumentAttributeValue(attribute, values);

            return result;
        }

        private static BooleanDocumentAttributeValue ToBoolean(BooleanDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            bool[] values = attributeValue.Values.ToArray();

            var result = new BooleanDocumentAttributeValue(attribute, values);

            return result;
        }

        private static DateDocumentAttributeValue ToDate(DateDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            UtcDateTime<DateDocumentAttributeValue>[] values =
                attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAttributeValue>.FromTimestamp).ToArray();

            var result = new DateDocumentAttributeValue(attribute, values);

            return result;
        }

        private static NumberDocumentAttributeValue ToNumber(IntDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            Number<NumberDocumentAttributeValue>[] values =
                attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValue>.FromInt).ToArray();

            var result = new NumberDocumentAttributeValue(attribute, values);

            return result;
        }

        private static NumberDocumentAttributeValue ToNumber(NumberDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            Number<NumberDocumentAttributeValue>[] values =
                attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValue>.FromLong).ToArray();

            var result = new NumberDocumentAttributeValue(attribute, values);

            return result;
        }

        private static ReferenceDocumentAttributeValue ToReference(ReferenceDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            string[] values = attributeValue.Values.ToArray();

            var result = new ReferenceDocumentAttributeValue(attribute, values);

            return result;
        }

        private static StringDocumentAttributeValue ToString(StringDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            string[] values = attributeValue.Values.ToArray();

            var result = new StringDocumentAttributeValue(attribute, values);

            return result;
        }

        private static TupleDocumentAttributeValue ToTuple(TupleDocumentAttributeValueDb attributeValue)
        {
            DocumentAttribute attribute = DocumentAttributeValueDataDbConverter.ToDomain(attributeValue.Data);

            TupleInnerValueDocumentAttributeValue[] values = [];

            var result = new TupleDocumentAttributeValue(attribute, values);

            return result;
        }
    }
}
