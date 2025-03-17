using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues;

namespace Edm.Document.Searcher.Domain.Documents.Services.Extractors;

public static class SearchDocumentAttributeValuesExtractor
{
    public static T? Extract<T>(SearchDocument document, int registryRoleId) where T : SearchDocumentAttributeValue
    {
        T? result = document.AttributesValues
            .OfType<T>()
            .SingleOrDefault(v => v.RegistryRoleId == registryRoleId);

        return result;
    }
}
