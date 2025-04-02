using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.Domains;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;

public interface IDocumentsRegistryRolesClient
{
    Task<DocumentRegistryRoleExternal[]> Get(string domainId, CancellationToken cancellationToken);

    Task<DocumentAttributeDocumentRegistryRolesExternal[]> GetDocumentsAttributes(string domainId, CancellationToken cancellationToken);

    Task<DomainExternal[]> GetDomains(string? query, CancellationToken cancellationToken);

    Task<DomainExternal?> GetDomainById(string domainId, CancellationToken cancellationToken);
}
