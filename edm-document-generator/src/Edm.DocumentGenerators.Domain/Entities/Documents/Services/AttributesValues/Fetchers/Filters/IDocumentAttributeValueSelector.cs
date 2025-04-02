using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.AttributesValues.Fetchers.Filters;

public interface IDocumentAttributeValueSelector<out TValue>
{
    public TValue[]? GetAllValues(DocumentAttributeValue attributeValue);

    public TValue[]? GetSingleValueOrNull(DocumentAttributeValue attributeValue);

    public TValue[]? GetSingleValue(DocumentAttributeValue attributeValue);
}
