using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Booleans;

internal static class DocumentBooleanAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentBooleanAttribute attribute)
    {
        bool[] value = attribute.DefaultValues.Length != 0
            ? attribute.DefaultValues
            : [false];

        var result = new BooleanDocumentAttributeValue(attribute, value);

        return result;
    }
}
