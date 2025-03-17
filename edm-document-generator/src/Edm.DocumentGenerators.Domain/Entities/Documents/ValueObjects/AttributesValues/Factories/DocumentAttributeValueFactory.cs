using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.Authors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.Classifications;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.ContractNumbers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Custom.SetCurrentUserToAttributes;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Attachments;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Booleans;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Dates;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Numbers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.References;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Strings;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Tuples;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories;

public static class DocumentAttributeValueFactory
{
    private static IDocumentAttributeValueFactory[] Factories { get; } =
    {
        new AuthorDocumentAttributeValueFactory(),
        new SetCurrentUserToAttributeDocumentAttributeValueFactory(),
        new ClassificationDocumentAttributeValueFactory(),
        new ContractNumberDocumentAttributeValueFactory(),
        new DefaultDocumentAttributeValueFactory()
    };

    public static DocumentAttributeValue CreateFrom(DocumentAttribute attribute)
    {
        DocumentAttributeValue result = attribute switch
        {
            DocumentAttachmentAttribute a => DocumentAttachmentAttributeValueFactory.CreateDefault(a),
            DocumentBooleanAttribute a => DocumentBooleanAttributeValueFactory.CreateDefault(a),
            DocumentDateAttribute a => DocumentDateAttributeValueFactory.CreateDefault(a),
            DocumentNumberAttribute a => DocumentNumberAttributeValueFactory.CreateDefault(a),
            DocumentReferenceAttribute a => DocumentReferenceAttributeValueFactory.CreateDefault(a),
            DocumentStringAttribute a => DocumentStringAttributeValueFactory.CreateDefault(a),
            DocumentTupleAttribute a => DocumentTupleAttributeValueFactory.CreateDefault(a),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }

    internal static DocumentAttributeValue CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        DocumentAttributeValue result = Create(attribute, context);

        return result;
    }

    private static DocumentAttributeValue Create(DocumentAttribute attribute, DocumentCreationContext context)
    {
        foreach (IDocumentAttributeValueFactory factory in Factories)
        {
            DocumentAttributeValue? attributeValue = factory.CreateFrom(attribute, context);

            if (attributeValue is not null)
            {
                return attributeValue;
            }
        }

        throw new BusinessLogicApplicationException($"Failed to create AttributeValue for attribute (id: {attribute.Id}, type: {attribute.GetType()})");
    }
}
