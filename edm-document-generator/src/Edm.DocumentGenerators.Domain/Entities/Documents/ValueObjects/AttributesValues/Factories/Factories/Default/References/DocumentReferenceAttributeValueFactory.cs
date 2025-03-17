using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.References;

internal static class DocumentReferenceAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentReferenceAttribute attribute)
    {
        string[] value = attribute.DefaultValues;

        var result = new ReferenceDocumentAttributeValue(attribute, value);

        return result;
    }
}
