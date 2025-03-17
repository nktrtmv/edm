using Edm.Document.Searcher.Domain.Documents.ValueObjects.AttributesValues.Inheritors.Strings;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors.Strings;

internal static class SearchDocumentStringAttributeValueDbConverter
{
    internal static SearchDocumentStringAttributeValueDb FromDomain(SearchDocumentStringAttributeValue attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new SearchDocumentStringAttributeValueDb
        {
            RegistryRoleId = registryRoleId,
            Values = attributeValue.Values
        };

        return result;
    }

    internal static SearchDocumentStringAttributeValue ToDomain(SearchDocumentStringAttributeValueDb attributeValue)
    {
        int registryRoleId = attributeValue.RegistryRoleId;

        var result = new SearchDocumentStringAttributeValue(registryRoleId, attributeValue.Values);

        return result;
    }
}
