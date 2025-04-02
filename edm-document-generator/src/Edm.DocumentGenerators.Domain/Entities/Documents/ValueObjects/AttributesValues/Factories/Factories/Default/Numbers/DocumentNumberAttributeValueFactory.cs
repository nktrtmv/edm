using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Numbers;

internal static class DocumentNumberAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentNumberAttribute attribute)
    {
        Number<NumberDocumentAttributeValue>[] value = attribute.DefaultValues.Select(NumberConverterFrom<NumberDocumentAttributeValue>.From).ToArray();

        var result = new NumberDocumentAttributeValue(attribute, value);

        return result;
    }
}
