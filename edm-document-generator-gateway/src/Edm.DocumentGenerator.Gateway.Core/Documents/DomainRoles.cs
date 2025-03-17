using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.Documents;

public sealed record DomainRoles
{
    private readonly Dictionary<int, string> _domainDocumentRoleIdToNameMap = [];
    private readonly Dictionary<string, int> _domainDocumentRoleNameToIdMap = [];
    private readonly Dictionary<int, string> _domainRegistryRoleIdToNameMap = [];
    private readonly Dictionary<string, int> _domainRegistryRoleNameToIdMap = [];

    public DomainRoles(
        string domainId,
        DocumentRegistryRoleExternal[] registryRoles,
        DocumentRoleExternal[] documentRoles)
    {
        DomainId = domainId;
        _domainRegistryRoleIdToNameMap = registryRoles.ToDictionary(x => x.Id, x => x.Name);
        _domainRegistryRoleNameToIdMap = registryRoles.ToDictionary(x => x.Name, x => x.Id);

        _domainDocumentRoleNameToIdMap = documentRoles.ToDictionary(x => x.Name, x => x.Id);
        _domainDocumentRoleIdToNameMap = documentRoles.ToDictionary(x => x.Id, x => x.Name);
    }

    public string DomainId { get; }

    public int GetRegistryRoleIdByName(string roleName)
    {
        if (!_domainRegistryRoleNameToIdMap.TryGetValue(roleName, out var id))
        {
            throw new ArgumentException($"Role with name {roleName} wasn't found");
        }

        return id;
    }

    public string GetRegistryRoleNameById(int roleId)
    {
        if (!_domainRegistryRoleIdToNameMap.TryGetValue(roleId, out var roleName))
        {
            throw new ArgumentException($"Role with id {roleId} wasn't found");
        }

        return roleName;
    }

    public int GetDocumentRoleIdByName(string roleName)
    {
        if (!_domainDocumentRoleNameToIdMap.TryGetValue(roleName, out var roleId))
        {
            throw new ArgumentException($"Role with name {roleName} wasn't found");
        }

        return roleId;
    }

    public string GetDocumentRoleNameById(int roleId)
    {
        if (!_domainDocumentRoleIdToNameMap.TryGetValue(roleId, out var roleName))
        {
            throw new ArgumentException($"Role with id {roleId} wasn't found");
        }

        return roleName;
    }
}
