using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.AttributesValues.Inheritors.Strings.Factories;

internal static class SearchDocumentStringAttributeValueInternalFactory
{
    internal static SearchDocumentStringAttributeValueInternal CreateFrom(
        SearchDocumentRegistryRoleInternal registryRole,
        params string[] values)
    {
        var result = new SearchDocumentStringAttributeValueInternal(registryRole, values);

        return result;
    }
}
