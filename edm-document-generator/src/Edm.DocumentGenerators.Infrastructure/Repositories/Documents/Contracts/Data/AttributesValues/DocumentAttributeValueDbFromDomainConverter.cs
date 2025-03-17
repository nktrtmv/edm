using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Data.AttributesValues;

internal static class DocumentAttributeValueDbFromDomainConverter
{
    internal static DocumentAttributeValueDb FromDomain(DocumentAttributeValue attributeValue)
    {
        DocumentAttributeValueDb result = attributeValue switch
        {
            AttachmentDocumentAttributeValue v => new DocumentAttributeValueDb { AsAttachment = ToAttachment(v) },
            BooleanDocumentAttributeValue v => new DocumentAttributeValueDb { AsBoolean = ToBoolean(v) },
            DateDocumentAttributeValue v => new DocumentAttributeValueDb { AsDate = ToDate(v) },
            NumberDocumentAttributeValue v => new DocumentAttributeValueDb { AsNumber = ToNumber(v) },
            ReferenceDocumentAttributeValue v => new DocumentAttributeValueDb { AsReference = ToReference(v) },
            StringDocumentAttributeValue v => new DocumentAttributeValueDb { AsString = ToString(v) },
            TupleDocumentAttributeValue v => new DocumentAttributeValueDb { AsTuple = ToTuple(v) },
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        DocumentAttributeDb attribute = DocumentAttributeDbFromDomainConverter.FromDomain(attributeValue.Attribute);

        result.Attribute = attribute;

        return result;
    }

    private static AttachmentDocumentAttributeValueDb ToAttachment(AttachmentDocumentAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new AttachmentDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static BooleanDocumentAttributeValueDb ToBoolean(BooleanDocumentAttributeValue attributeValue)
    {
        bool[] values = attributeValue.Values.ToArray();

        var result = new BooleanDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static DateDocumentAttributeValueDb ToDate(DateDocumentAttributeValue attributeValue)
    {
        Timestamp[] values = attributeValue.Values.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new DateDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static NumberDocumentAttributeValueDb ToNumber(NumberDocumentAttributeValue attributeValue)
    {
        long[] values = attributeValue.Values.Select(NumberConverterTo.ToLong).ToArray();

        var result = new NumberDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static ReferenceDocumentAttributeValueDb ToReference(ReferenceDocumentAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new ReferenceDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static StringDocumentAttributeValueDb ToString(StringDocumentAttributeValue attributeValue)
    {
        string[] values = attributeValue.Values.ToArray();

        var result = new StringDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static TupleDocumentAttributeValueDb ToTuple(TupleDocumentAttributeValue documentAttributeValue)
    {
        TupleInnerDocumentAttributeValueDb[] values = documentAttributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new TupleDocumentAttributeValueDb
        {
            Values = { values }
        };

        return result;
    }

    private static TupleInnerDocumentAttributeValueDb ToTupleValue(TupleInnerValueDocumentAttributeValue value)
    {
        DocumentAttributeValueDb[] innerValues = value.InnerValues.Select(FromDomain).ToArray();

        var result = new TupleInnerDocumentAttributeValueDb
        {
            InnerValues = { innerValues }
        };

        return result;
    }
}
