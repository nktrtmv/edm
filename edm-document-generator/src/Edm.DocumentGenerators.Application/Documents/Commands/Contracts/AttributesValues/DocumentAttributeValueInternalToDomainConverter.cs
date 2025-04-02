using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.AttributesValues;

internal static class DocumentAttributeValueBareInternalToDomainConverter
{
    internal static DocumentAttributeValue[] ToDomain(
        DocumentAttributeValueInternal[] attributesValues,
        DocumentAttribute[] attributes)
    {
        Dictionary<string, DocumentAttribute> attributesById = attributes.ToDictionary(p => IdConverterTo.ToString(p.Id));

        DocumentAttributeValue[] result = attributesValues.Select(v => ToDomain(v, attributesById)).ToArray();

        return result;
    }

    private static DocumentAttributeValue ToDomain(
        DocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        DocumentAttributeValue result = attributeValue switch
        {
            AttachmentDocumentAttributeValueInternal v => ToAttachment(v, attributesById),
            BooleanDocumentAttributeValueInternal v => ToBoolean(v, attributesById),
            DateDocumentAttributeValueInternal v => ToDate(v, attributesById),
            NumberDocumentAttributeValueInternal v => ToNumber(v, attributesById),
            ReferenceDocumentAttributeValueInternal v => ToReference(v, attributesById),
            StringDocumentAttributeValueInternal v => ToString(v, attributesById),
            TupleDocumentAttributeValueInternal v => ToTuple(v, attributesById),
            _ => throw new ArgumentTypeOutOfRangeException(attributeValue)
        };

        return result;
    }

    private static AttachmentDocumentAttributeValue ToAttachment(
        AttachmentDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentAttachmentAttribute>(attributeValue.AttributeId, attributesById);

        var result = new AttachmentDocumentAttributeValue(attribute, attributeValue.Values);

        return result;
    }

    private static BooleanDocumentAttributeValue ToBoolean(
        BooleanDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentBooleanAttribute>(attributeValue.AttributeId, attributesById);

        var result = new BooleanDocumentAttributeValue(attribute, attributeValue.Values);

        return result;
    }

    private static DateDocumentAttributeValue ToDate(
        DateDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentDateAttribute>(attributeValue.AttributeId, attributesById);

        UtcDateTime<DateDocumentAttributeValue>[] values =
            attributeValue.Values.Select(UtcDateTimeConverterFrom<DateDocumentAttributeValue>.From).ToArray();

        var result = new DateDocumentAttributeValue(attribute, values);

        return result;
    }

    private static NumberDocumentAttributeValue ToNumber(
        NumberDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentNumberAttribute>(attributeValue.AttributeId, attributesById);

        Number<NumberDocumentAttributeValue>[] values =
            attributeValue.Values.Select(NumberConverterFrom<NumberDocumentAttributeValue>.From).ToArray();

        var result = new NumberDocumentAttributeValue(attribute, values);

        return result;
    }

    private static ReferenceDocumentAttributeValue ToReference(
        ReferenceDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentReferenceAttribute>(attributeValue.AttributeId, attributesById);

        var result = new ReferenceDocumentAttributeValue(attribute, attributeValue.Values);

        return result;
    }

    private static StringDocumentAttributeValue ToString(
        StringDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentStringAttribute>(attributeValue.AttributeId, attributesById);

        var result = new StringDocumentAttributeValue(attribute, attributeValue.Values);

        return result;
    }

    private static TupleDocumentAttributeValue ToTuple(
        TupleDocumentAttributeValueInternal attributeValue,
        Dictionary<string, DocumentAttribute> attributesById)
    {
        var attribute = GetAttribute<DocumentTupleAttribute>(attributeValue.AttributeId, attributesById);

        TupleInnerValueDocumentAttributeValue[] values =
            attributeValue.Values.Select(v => ToTupleValue(v, attribute.InnerAttributes)).ToArray();

        var result = new TupleDocumentAttributeValue(attribute, values);

        return result;
    }

    private static TupleInnerValueDocumentAttributeValue ToTupleValue(
        TupleInnerValueDocumentAttributeValueInternal value,
        DocumentAttribute[] innerAttributes)
    {
        DocumentAttributeValue[] innerValues = ToDomain(value.InnerValues, innerAttributes);

        var result = new TupleInnerValueDocumentAttributeValue(innerValues);

        return result;
    }

    private static T GetAttribute<T>(string attributeId, Dictionary<string, DocumentAttribute> attributesById) where T : DocumentAttribute
    {
        DocumentAttribute? attribute = attributesById.GetValueOrDefault(attributeId);

        if (attribute is null)
        {
            throw new BusinessLogicApplicationException($"AttributeValue attribute (id: {attributeId}) is not found among existing attributes.");
        }

        if (attribute is not T result)
        {
            throw new UnsupportedTypeArgumentException<T>(attribute);
        }

        return result;
    }
}
