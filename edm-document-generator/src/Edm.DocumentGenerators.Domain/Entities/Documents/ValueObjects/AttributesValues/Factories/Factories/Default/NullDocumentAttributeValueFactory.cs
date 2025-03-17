using Edm.DocumentGenerators.Domain.Entities.Documents.Factories.CreationContext;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors.InnerValues;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Abstractions;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default;

public sealed class NullDocumentAttributeValueFactory : IDocumentAttributeValueFactory
{
    DocumentAttributeValue IDocumentAttributeValueFactory.CreateFrom(DocumentAttribute attribute, DocumentCreationContext context)
    {
        DocumentAttributeValue result = CreateFrom(attribute);

        return result;
    }

    public static DocumentAttributeValue CreateFrom(DocumentAttribute attribute)
    {
        DocumentAttributeValue result = attribute switch
        {
            DocumentAttachmentAttribute a => new AttachmentDocumentAttributeValue(a, Array.Empty<string>()),
            DocumentBooleanAttribute a => new BooleanDocumentAttributeValue(a, Array.Empty<bool>()),
            DocumentDateAttribute a => new DateDocumentAttributeValue(a, Array.Empty<UtcDateTime<DateDocumentAttributeValue>>()),
            DocumentNumberAttribute a => new NumberDocumentAttributeValue(a, Array.Empty<Number<NumberDocumentAttributeValue>>()),
            DocumentReferenceAttribute a => new ReferenceDocumentAttributeValue(a, Array.Empty<string>()),
            DocumentStringAttribute a => new StringDocumentAttributeValue(a, Array.Empty<string>()),
            DocumentTupleAttribute a => new TupleDocumentAttributeValue(a, Array.Empty<TupleInnerValueDocumentAttributeValue>()),
            _ => throw new ArgumentTypeOutOfRangeException(attribute)
        };

        return result;
    }
}
