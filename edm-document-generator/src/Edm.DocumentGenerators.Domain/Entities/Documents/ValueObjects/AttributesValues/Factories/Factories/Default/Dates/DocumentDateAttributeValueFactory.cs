using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.ValueObjects.Attributes.Inheritors;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Factories.Factories.Default.Dates;

internal static class DocumentDateAttributeValueFactory
{
    internal static DocumentAttributeValue CreateDefault(DocumentDateAttribute attribute)
    {
        UtcDateTime<DateDocumentAttributeValue>[] value = attribute.DefaultValues.Select(UtcDateTimeConverterFrom<DateDocumentAttributeValue>.From).ToArray();

        var result = new DateDocumentAttributeValue(attribute, value);

        return result;
    }
}
