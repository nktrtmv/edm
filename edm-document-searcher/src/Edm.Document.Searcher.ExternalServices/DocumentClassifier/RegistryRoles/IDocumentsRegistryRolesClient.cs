using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles;

public interface IDocumentsRegistryRolesClient
{
    Task<DocumentRegistryRoleExternal[]> Get(DomainId domainId, CancellationToken cancellationToken);
}
