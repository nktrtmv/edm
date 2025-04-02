using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.Audits.Records.Inheritors.AttributesValuesChanged.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.Audits.Records.AttributesValuesChanged.Changes.AttributesValues;

internal static class DocumentAuditAttributeValueDbFromDomainConverter
{
    internal static DocumentAuditAttributeValueDb FromDomain(DocumentAuditAttributeValue attributeValue)
    {
        DocumentAuditAttributeValueDb result = attributeValue switch
        {
            AttachmentDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsAttachment = ToAttachment(v) },
            BooleanDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsBoolean = ToBoolean(v) },
            DateDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsDate = ToDate(v) },
            NumberDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsNumber = ToNumber(v) },
            ReferenceDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsReference = ToReference(v) },
            StringDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsString = ToString(v) },
            TupleDocumentAuditAttributeValue v => new DocumentAuditAttributeValueDb { AsTuple = ToTuple(v) },
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        var attributeId = IdConverterTo.ToString(attributeValue.Id);

        result.AttributeId = attributeId;

        return result;
    }

    private static AttachmentDocumentAuditAttributeValueDb ToAttachment(AttachmentDocumentAuditAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new AttachmentDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static BooleanDocumentAuditAttributeValueDb ToBoolean(BooleanDocumentAuditAttributeValue attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static DateDocumentAuditAttributeValueDb ToDate(DateDocumentAuditAttributeValue attributeValue)
    {
        Timestamp[] values = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new DateDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static NumberDocumentAuditAttributeValueDb ToNumber(NumberDocumentAuditAttributeValue attributeValue)
    {
        long[] values = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var result = new NumberDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static ReferenceDocumentAuditAttributeValueDb ToReference(ReferenceDocumentAuditAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static StringDocumentAuditAttributeValueDb ToString(StringDocumentAuditAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static TupleDocumentAuditAttributeValueDb ToTuple(TupleDocumentAuditAttributeValue attributeValue)
    {
        TupleInnerDocumentAuditAttributeValueDb[] values = attributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAuditAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static TupleInnerDocumentAuditAttributeValueDb ToTupleValue(DocumentTupleAuditAttributeInnerValue value)
    {
        DocumentAuditAttributeValueDb[] innerValues = value.InnerValues.Select(FromDomain).ToArray();

        var result = new TupleInnerDocumentAuditAttributeValueDb
        {
            InnerValues = { innerValues }
        };

        return result;
    }
}
