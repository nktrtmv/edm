using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.Audits.Records.AttributesValuesChanged.AttributesValues;

internal static class DocumentAuditAttributeValueInternalFromDomainConverter
{
    internal static DocumentAttributeValueInternal FromDomain(DocumentAuditAttributeValue attributeValue)
    {
        Id<DocumentAttributeInternal> attributeId = IdConverterFrom<DocumentAttributeInternal>.From(attributeValue.Id);

        DocumentAttributeValueInternal result = attributeValue switch
        {
            AttachmentDocumentAuditAttributeValue v => ToAttachment(attributeId, v),
            BooleanDocumentAuditAttributeValue v => ToBoolean(attributeId, v),
            DateDocumentAuditAttributeValue v => ToDate(attributeId, v),
            NumberDocumentAuditAttributeValue v => ToNumber(attributeId, v),
            ReferenceDocumentAuditAttributeValue v => ToReference(attributeId, v),
            StringDocumentAuditAttributeValue v => ToString(attributeId, v),
            TupleDocumentAuditAttributeValue v => ToTuple(attributeId, v),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static DocumentAttributeValueInternal ToAttachment(
        Id<DocumentAttributeInternal> attributeId,
        AttachmentDocumentAuditAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new AttachmentDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static DocumentAttributeValueInternal ToBoolean(
        Id<DocumentAttributeInternal> attributeId,
        BooleanDocumentAuditAttributeValue attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static DocumentAttributeValueInternal ToDate(
        Id<DocumentAttributeInternal> attributeId,
        DateDocumentAuditAttributeValue attributeValue)
    {
        UtcDateTime<DateDocumentAttributeValueInternal>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAttributeValueInternal>.From).ToArray();

        var result = new DateDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static DocumentAttributeValueInternal ToNumber(
        Id<DocumentAttributeInternal> attributeId,
        NumberDocumentAuditAttributeValue attributeValue)
    {
        Number<NumberDocumentAttributeValueInternal>[] values =
            attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValueInternal>.From).ToArray();

        var result = new NumberDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static DocumentAttributeValueInternal ToReference(
        Id<DocumentAttributeInternal> attributeId,
        ReferenceDocumentAuditAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static DocumentAttributeValueInternal ToString(Id<DocumentAttributeInternal> attributeId, StringDocumentAuditAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static DocumentAttributeValueInternal ToTuple(Id<DocumentAttributeInternal> attributeId, TupleDocumentAuditAttributeValue attributeValue)
    {
        TupleInnerValueDocumentAttributeValueInternal[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAttributeValueInternal(attributeId.ToString(), values);

        return result;
    }

    private static TupleInnerValueDocumentAttributeValueInternal ToTupleValue(DocumentTupleAuditAttributeInnerValue innerValue)
    {
        DocumentAttributeValueInternal[] innerValues = innerValue.InnerValues.Select(FromDomain).ToArray();

        var result = new TupleInnerValueDocumentAttributeValueInternal(innerValues);

        return result;
    }
}
