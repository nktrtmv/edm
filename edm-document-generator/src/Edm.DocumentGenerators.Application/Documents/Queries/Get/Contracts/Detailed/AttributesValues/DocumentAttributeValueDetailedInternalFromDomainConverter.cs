using Edm.DocumentGenerators.Application.Contracts.Attributes.Abstractions;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Attachments;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Booleans;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Dates;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Numbers;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.References;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Strings;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples;
using Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues.Inheritors.Tuples.InnerValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Application.Documents.Queries.Get.Contracts.Detailed.AttributesValues;

internal static class DocumentAttributeValueDetailedInternalFromDomainConverter
{
    internal static DocumentAttributeValueDetailedInternal FromDomain(DocumentAttributeValue attributeValue)
    {
        DocumentAttributeInternal attribute = DocumentAttributeInternalFromDomainConverter.FromDomain(attributeValue.Attribute);

        DocumentAttributeValueDetailedInternal result = attributeValue switch
        {
            AttachmentDocumentAttributeValue v => ToAttachment(attribute, v),
            BooleanDocumentAttributeValue v => ToBoolean(attribute, v),
            DateDocumentAttributeValue v => ToDate(attribute, v),
            NumberDocumentAttributeValue v => ToNumber(attribute, v),
            ReferenceDocumentAttributeValue v => ToReference(attribute, v),
            StringDocumentAttributeValue v => ToString(attribute, v),
            TupleDocumentAttributeValue v => ToTuple(attribute, v),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static DocumentAttachmentAttributeValueDetailedInternal ToAttachment(DocumentAttributeInternal attribute, AttachmentDocumentAttributeValue attributeValue)
    {
        var result = new DocumentAttachmentAttributeValueDetailedInternal(attribute, attributeValue.Values);

        return result;
    }

    private static DocumentBooleanAttributeValueDetailedInternal ToBoolean(DocumentAttributeInternal attribute, BooleanDocumentAttributeValue attributeValue)
    {
        var result = new DocumentBooleanAttributeValueDetailedInternal(attribute, attributeValue.Values);

        return result;
    }

    private static DocumentDateAttributeValueDetailedInternal ToDate(DocumentAttributeInternal attribute, DateDocumentAttributeValue attributeValue)
    {
        UtcDateTime<DocumentDateAttributeValueDetailedInternal>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DocumentDateAttributeValueDetailedInternal>.From).ToArray();

        var result = new DocumentDateAttributeValueDetailedInternal(attribute, values);

        return result;
    }

    private static DocumentNumberAttributeValueDetailedInternal ToNumber(DocumentAttributeInternal attribute, NumberDocumentAttributeValue attributeValue)
    {
        Number<DocumentNumberAttributeValueDetailedInternal>[] values =
            attributeValue.Values.Select(NumberConverterFrom<DocumentNumberAttributeValueDetailedInternal>.From).ToArray();

        var result = new DocumentNumberAttributeValueDetailedInternal(attribute, values);

        return result;
    }

    private static DocumentReferenceAttributeValueDetailedInternal ToReference(DocumentAttributeInternal attribute, ReferenceDocumentAttributeValue attributeValue)
    {
        var result = new DocumentReferenceAttributeValueDetailedInternal(attribute, attributeValue.Values);

        return result;
    }

    private static DocumentStringAttributeValueDetailedInternal ToString(DocumentAttributeInternal attribute, StringDocumentAttributeValue attributeValue)
    {
        var result = new DocumentStringAttributeValueDetailedInternal(attribute, attributeValue.Values);

        return result;
    }

    private static DocumentTupleAttributeValueDetailedInternal ToTuple(DocumentAttributeInternal attribute, TupleDocumentAttributeValue documentAttributeValue)
    {
        DocumentTupleAttributeValueInnerValueDetailedInternal[] values = documentAttributeValue.Values.Select(ToTupleValue).ToArray();

        var result = new DocumentTupleAttributeValueDetailedInternal(attribute, values);

        return result;
    }

    private static DocumentTupleAttributeValueInnerValueDetailedInternal ToTupleValue(TupleInnerValueDocumentAttributeValue value)
    {
        DocumentAttributeValueDetailedInternal[] innerValues = value.InnerValues.Select(FromDomain).ToArray();

        var result = new DocumentTupleAttributeValueInnerValueDetailedInternal(innerValues);

        return result;
    }
}
