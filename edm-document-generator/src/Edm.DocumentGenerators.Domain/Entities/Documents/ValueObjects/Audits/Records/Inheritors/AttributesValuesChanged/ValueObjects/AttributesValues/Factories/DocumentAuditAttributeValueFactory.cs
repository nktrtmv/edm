using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Factories;

public static class DocumentAuditAttributeValueFactory
{
    internal static DocumentAuditAttributeValue CreateFrom(DocumentAttributeValue attributeValue)
    {
        DocumentAuditAttributeValue result = attributeValue switch
        {
            AttachmentDocumentAttributeValue v => ToAttachment(v),
            BooleanDocumentAttributeValue v => ToBoolean(v),
            DateDocumentAttributeValue v => ToDate(v),
            NumberDocumentAttributeValue v => ToNumber(v),
            ReferenceDocumentAttributeValue v => ToReference(v),
            StringDocumentAttributeValue v => ToString(v),
            TupleDocumentAttributeValue v => ToTuple(v),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static AttachmentDocumentAuditAttributeValue ToAttachment(AttachmentDocumentAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new AttachmentDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static BooleanDocumentAuditAttributeValue ToBoolean(BooleanDocumentAttributeValue attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static DateDocumentAuditAttributeValue ToDate(DateDocumentAttributeValue attributeValue)
    {
        UtcDateTime<DateDocumentAuditAttributeValue>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAuditAttributeValue>.From).ToArray();

        var result = new DateDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static NumberDocumentAuditAttributeValue ToNumber(NumberDocumentAttributeValue attributeValue)
    {
        Number<NumberDocumentAuditAttributeValue>[] values =
            attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAuditAttributeValue>.From).ToArray();

        var result = new NumberDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static ReferenceDocumentAuditAttributeValue ToReference(ReferenceDocumentAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static StringDocumentAuditAttributeValue ToString(StringDocumentAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static TupleDocumentAuditAttributeValue ToTuple(TupleDocumentAttributeValue attributeValue)
    {
        DocumentTupleAuditAttributeInnerValue[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAuditAttributeValue(attributeValue.Id, values);

        return result;
    }

    private static DocumentTupleAuditAttributeInnerValue ToTupleValue(TupleInnerValueDocumentAttributeValue value)
    {
        DocumentAuditAttributeValue[] innerValues = value.InnerValues.Select(CreateFrom).ToArray();

        var result = new DocumentTupleAuditAttributeInnerValue(innerValues);

        return result;
    }
}
