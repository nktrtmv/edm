using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes.Abstractions.Data;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Contracts.Data.Attributes;

internal static class DocumentAttributeDbFromDomainConverter
{
    internal static DocumentAttributeDb FromDomain(DocumentAttribute attribute)
    {
        DocumentAttributeDb result = attribute switch
        {
            DocumentAttachmentAttribute a => new DocumentAttributeDb { AsAttachment = ToAttachment(a) },
            DocumentBooleanAttribute a => new DocumentAttributeDb { AsBoolean = ToBoolean(a) },
            DocumentDateAttribute a => new DocumentAttributeDb { AsDate = ToDate(a) },
            DocumentNumberAttribute a => new DocumentAttributeDb { AsNumber = ToNumber(a) },
            DocumentReferenceAttribute a => new DocumentAttributeDb { AsReference = ToReference(a) },
            DocumentStringAttribute a => new DocumentAttributeDb { AsString = ToString(a) },
            DocumentTupleAttribute a => new DocumentAttributeDb { AsTuple = ToTuple(a) },
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        DocumentAttributeDataDb data = DocumentAttributeDataDbConverter.FromDomain(attribute.Data);

        result.Data = data;

        return result;
    }

    private static DocumentStringAttributeDb ToString(DocumentStringAttribute attribute)
    {
        var result = new DocumentStringAttributeDb
        {
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentAttachmentAttributeDb ToAttachment(DocumentAttachmentAttribute attribute)
    {
        var result = new DocumentAttachmentAttributeDb
        {
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentBooleanAttributeDb ToBoolean(DocumentBooleanAttribute attribute)
    {
        var result = new DocumentBooleanAttributeDb
        {
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentDateAttributeDb ToDate(DocumentDateAttribute attribute)
    {
        Timestamp[] defaultValues = attribute.DefaultValues.Select(UtcDateTimeConverterTo.ToTimeStamp).ToArray();

        var result = new DocumentDateAttributeDb
        {
            DefaultValues = { defaultValues }
        };

        return result;
    }

    private static DocumentNumberAttributeDb ToNumber(DocumentNumberAttribute attribute)
    {
        long[] defaultValues = attribute.DefaultValues.Select(NumberConverterTo.ToLong).ToArray();

        var result = new DocumentNumberAttributeDb
        {
            Precision = attribute.Precision,
            DefaultValues = { defaultValues }
        };

        return result;
    }

    private static DocumentReferenceAttributeDb ToReference(DocumentReferenceAttribute attribute)
    {
        var referenceType = MetadataConverterTo.ToString(attribute.ReferenceType);

        var result = new DocumentReferenceAttributeDb
        {
            ReferenceType = referenceType,
            DefaultValues = { attribute.DefaultValues }
        };

        return result;
    }

    private static DocumentTupleAttributeDb ToTuple(DocumentTupleAttribute attribute)
    {
        DocumentAttributeDb[] innerAttributes = attribute.InnerAttributes.Select(FromDomain).ToArray();

        var result = new DocumentTupleAttributeDb
        {
            InnerAttributes = { innerAttributes }
        };

        return result;
    }
}
