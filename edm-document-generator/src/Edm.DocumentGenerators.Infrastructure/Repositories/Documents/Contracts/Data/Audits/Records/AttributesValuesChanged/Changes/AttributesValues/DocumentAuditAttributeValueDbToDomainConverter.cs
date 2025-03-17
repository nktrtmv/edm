using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged.Changes.AttributesValues;

internal static class DocumentAuditAttributeValueDbToDomainConverter
{
    internal static DocumentAuditAttributeValue ToDomain(DocumentAuditAttributeValueDb attributeValue)
    {
        Id<DocumentAttribute> attributeId = IdConverterFrom<DocumentAttribute>.FromString(attributeValue.AttributeId);

        DocumentAuditAttributeValue result = attributeValue.ValueCase switch
        {
            DocumentAuditAttributeValueDb.ValueOneofCase.AsAttachment => ToAttachment(attributeId, attributeValue.AsAttachment),
            DocumentAuditAttributeValueDb.ValueOneofCase.AsBoolean => ToBoolean(attributeId, attributeValue.AsBoolean),
            DocumentAuditAttributeValueDb.ValueOneofCase.AsDate => ToDate(attributeId, attributeValue.AsDate),
            DocumentAuditAttributeValueDb.ValueOneofCase.AsNumber => ToNumber(attributeId, attributeValue.AsNumber),
            DocumentAuditAttributeValueDb.ValueOneofCase.AsReference => ToReference(attributeId, attributeValue.AsReference),
            DocumentAuditAttributeValueDb.ValueOneofCase.AsString => ToString(attributeId, attributeValue.AsString),
            DocumentAuditAttributeValueDb.ValueOneofCase.AsTuple => ToTuple(attributeId, attributeValue.AsTuple),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue.ValueCase)
        };

        return result;
    }

    private static DocumentAuditAttributeValue ToAttachment(Id<DocumentAttribute> attributeId, AttachmentDocumentAuditAttributeValueDb attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();
        var result = new AttachmentDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentAuditAttributeValue ToBoolean(Id<DocumentAttribute> attributeId, BooleanDocumentAuditAttributeValueDb attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentAuditAttributeValue ToDate(Id<DocumentAttribute> attributeId, DateDocumentAuditAttributeValueDb attributeValue)
    {
        UtcDateTime<DateDocumentAuditAttributeValue>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAuditAttributeValue>.FromTimestamp).ToArray();

        var result = new DateDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentAuditAttributeValue ToNumber(Id<DocumentAttribute> attributeId, NumberDocumentAuditAttributeValueDb attributeValue)
    {
        Number<NumberDocumentAuditAttributeValue>[] values = attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAuditAttributeValue>.FromLong).ToArray();

        var result = new NumberDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentAuditAttributeValue ToReference(Id<DocumentAttribute> attributeId, ReferenceDocumentAuditAttributeValueDb attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentAuditAttributeValue ToString(Id<DocumentAttribute> attributeId, StringDocumentAuditAttributeValueDb attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentAuditAttributeValue ToTuple(Id<DocumentAttribute> attributeId, TupleDocumentAuditAttributeValueDb attributeValue)
    {
        DocumentTupleAuditAttributeInnerValue[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAuditAttributeValue(attributeId, values);

        return result;
    }

    private static DocumentTupleAuditAttributeInnerValue ToTupleValue(TupleInnerDocumentAuditAttributeValueDb value)
    {
        DocumentAuditAttributeValue[] innerValues = value.InnerValues.Select(ToDomain).ToArray();

        var result = new DocumentTupleAuditAttributeInnerValue(innerValues);

        return result;
    }
}
