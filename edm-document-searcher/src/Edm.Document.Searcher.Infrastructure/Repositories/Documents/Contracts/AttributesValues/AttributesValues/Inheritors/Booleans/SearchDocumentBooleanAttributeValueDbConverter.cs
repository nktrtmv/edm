using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Booleans;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Booleans;

internal static class SearchDocumentBooleanAttributeValueDbConverter
{
    internal static SearchDocumentBooleanAttributeValueDb FromDomain(SearchDocumentBooleanAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new SearchDocumentBooleanAttributeValueDb
        {
            RegistryRoleId = registryRoleId,
            Values = attributeValue.Values
        };

        return result;
    }

    internal static SearchDocumentBooleanAttributeValue ToDomain(SearchDocumentBooleanAttributeValueDb attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new SearchDocumentBooleanAttributeValue(registryRoleId, attributeValue.Values);

        return result;
    }
}
