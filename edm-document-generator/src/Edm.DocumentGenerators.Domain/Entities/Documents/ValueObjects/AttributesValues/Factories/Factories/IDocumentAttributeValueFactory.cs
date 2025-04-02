using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories;

internal interface IDocumentAttributeValueFactory
{
    DocumentAttributeValue? CreateFrom(DocumentAttribute attribute, DocumentCreationContext context);
}
