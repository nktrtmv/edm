using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.Documents;

public sealed class RoleAdapter(IDocumentsRegistryRolesClient documentsRegistryRolesClient, IDocumentsRolesClient documentsRolesClient) : IRoleAdapter
{
    public async Task<DomainRoles> GetDomainRoles(string domainId, CancellationToken cancellationToken)
    {
        var result = await BuildDomainRoles(domainId, cancellationToken);

        return result;
    }

    private async Task<DomainRoles> BuildDomainRoles(string domainId, CancellationToken cancellationToken)
    {
        DocumentRegistryRoleExternal[] registryRoles = await documentsRegistryRolesClient.Get(domainId, cancellationToken);
        DocumentRoleExternal[] documentRoles = (await documentsRolesClient.GetAll(domainId, cancellationToken))
            .SelectMany(y => y.roles)
            .Distinct()
            .ToArray();

        var result = new DomainRoles(domainId, registryRoles, documentRoles);

        return result;
    }
}
