using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Collectors;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.AttributesValues.Services.Fetchers;

public static class DocumentAttributeValueStringByRoleFetcher
{
    public static string? FetchSingleOrDefaultValue(Document document, int role)
    {
        StringDocumentAttributeValue[] attributesValues =
            DocumentAttributesValuesCollector.Collect(document.AttributesValues).OfType<StringDocumentAttributeValue>().ToArray();

        StringDocumentAttributeValue? attributeValue =
            attributesValues.SingleOrDefault(v => v.Attribute.Data.DocumentsRoles.Contains(role));

        string? result = attributeValue?.Values.SingleOrDefault();

        return result;
    }

    public static string? FetchFirstOrDefaultValue(Document document, int role)
    {
        StringDocumentAttributeValue[] attributesValues =
            DocumentAttributesValuesCollector.Collect(document.AttributesValues).OfType<StringDocumentAttributeValue>().ToArray();

        StringDocumentAttributeValue? attributeValue =
            attributesValues.FirstOrDefault(v => v.Attribute.Data.DocumentsRoles.Contains(role));

        string? result = attributeValue?.Values.FirstOrDefault();

        return result;
    }
}
