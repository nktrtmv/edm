using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default;

public sealed class DefaultDocumentAttributeValueFactory : IDocumentAttributeValueFactory
{
    DocumentAttributeValue IDocumentAttributeValueFactory.CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        DocumentAttributeValue result = DocumentAttributeValueFactory.CreateFrom(attribute);

        return result;
    }
}
