using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Strings;

internal static class DocumentStringAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentStringAttribute attribute)
    {
        string[] value = attribute.DefaultValues;

        var result = new StringDocumentAttributeValue(attribute, value);

        return result;
    }
}
