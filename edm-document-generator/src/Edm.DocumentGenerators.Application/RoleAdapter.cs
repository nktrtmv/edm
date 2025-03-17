using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentRoles;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.Domains;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions.Rpc.BusinessLogic;

namespace Edm.DocumentGenerators.Application;

internal sealed class RoleAdapter(IDocumentRolesClient documentRolesClient, IDomainsClient domainsClient) : IRoleAdapter
{
    private static Dictionary<string, Dictionary<int, string>> DomainDocumentRoleIdToDisplayMap = [];

    public string GetDocumentRoleDisplayById(string domainId, int id)
    {
        if (!DomainDocumentRoleIdToDisplayMap.TryGetValue(domainId, out Dictionary<int, string>? idToDisplayMap))
        {
            throw new BusinessLogicApplicationException($"Domain with id {domainId} wasn't found");
        }

        if (!idToDisplayMap.TryGetValue(id, out string? display))
        {
            throw new BusinessLogicApplicationException($"Domain with id {domainId} wasn't found");
        }

        return display;
    }

    public Task WarmUp(CancellationToken cancellationToken)
    {
        return Reload(cancellationToken);
    }

    private async Task Reload(CancellationToken cancellationToken)
    {
        List<DomainExternal>? domains = await domainsClient.GetAllDomains(cancellationToken);

        IEnumerable<Task<(string domainId, List<DocumentRoleExternal> roles)>> rolesTasks = domains
            .Select(x => x.Id)
            .Select(async x => (x, await documentRolesClient.GetDocumentRoles(x, cancellationToken)))
            .ToList();

        (string domainId, List<DocumentRoleExternal> roles)[]? roles = await Task.WhenAll(rolesTasks);
        DomainDocumentRoleIdToDisplayMap = roles.ToDictionary(
            x => x.domainId,
            x => x.roles
                .DistinctBy(y => y.Id)
                .ToDictionary(y => y.Id, GetDisplay));
    }

    private static string GetDisplay(DocumentRoleExternal documentRoleExternal)
    {
        if (!string.IsNullOrWhiteSpace(documentRoleExternal.Display))
        {
            return documentRoleExternal.Display;
        }

        return !string.IsNullOrWhiteSpace(documentRoleExternal.Name)
            ? documentRoleExternal.Name
            : documentRoleExternal.Id.ToString();
    }
}
