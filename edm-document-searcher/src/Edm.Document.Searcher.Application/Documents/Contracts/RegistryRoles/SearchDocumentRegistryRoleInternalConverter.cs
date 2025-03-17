using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Kinds;
using Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles.Types;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;

namespace Edm.Document.Searcher.Application.Documents.Contracts.RegistryRoles;

public static class SearchDocumentRegistryRoleInternalConverter
{
    public static SearchDocumentRegistryRoleInternal FromExternal(DocumentRegistryRoleExternal registryRole)
    {
        SearchDocumentRegistryRoleTypeInternal type = SearchDocumentRegistryRoleTypeInternalFromExternalConverter.FromExternal(registryRole.Type);

        var result = new SearchDocumentRegistryRoleInternal(registryRole.Id, type, (SearchDocumentRegistryRoleKindInternal)registryRole.Kind);

        return result;
    }
}
