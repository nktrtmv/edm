using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Services.AttributeValuesExtractor;

internal sealed class DocumentsAttributesValuesExtractor
{
    internal DocumentsAttributesValuesExtractor(Document document)
    {
        Document = document;
    }

    private Document Document { get; }

    internal DocumentAttributeValue GetRequiredAttributeValue(Id<DocumentAttribute> attributeId)
    {
        DocumentAttributeValue? result = Document.AttributesValues.FirstOrDefault(a => a.Id == attributeId);

        if (result is null)
        {
            throw new BusinessLogicApplicationException(
                $"""
                 Attribute is not found.
                 DocumentId: {Document.Id}
                 Id: {attributeId}
                 """);
        }

        return result;
    }

    internal Id<User>[] GetRecipientsIds(Id<DocumentAttribute> recipientAttributeId)
    {
        DocumentAttributeValue recipientAttributeValue = GetRequiredAttributeValue(recipientAttributeId);

        if (recipientAttributeValue is not ReferenceDocumentAttributeValue recipientReferenceAttributeValue)
        {
            throw new UnsupportedTypeArgumentException<ReferenceDocumentAttributeValue>(recipientAttributeValue);
        }

        if (recipientReferenceAttributeValue.Attribute is not DocumentReferenceAttribute)
        {
            throw new UnsupportedTypeArgumentException<DocumentReferenceAttribute>(recipientReferenceAttributeValue.Attribute);
        }

        Id<User>[] result = recipientReferenceAttributeValue.Values.Select(IdConverterFrom<User>.FromString).ToArray();

        return result;
    }
}
