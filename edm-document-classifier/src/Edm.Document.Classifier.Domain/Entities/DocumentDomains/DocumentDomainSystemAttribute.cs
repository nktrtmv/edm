using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public sealed class DocumentDomainSystemAttribute(
    SystemAttributeId id,
    DisplayName displayName,
    SystemName systemName,
    bool isArray,
    TypeSettings typeSettings,
    HashSet<RegistryRoleId> registryRolesIds,
    HashSet<DocumentRoleId> documentRoleIds)
{
    public SystemAttributeId Id { get; private set; } = id;
    public DisplayName DisplayName { get; private set; } = displayName;
    public SystemName SystemName { get; private set; } = systemName;
    public bool IsArray { get; private set; } = isArray;
    public HashSet<RegistryRoleId> RegistryRolesIds { get; private set; } = registryRolesIds;
    public HashSet<DocumentRoleId> DocumentRoleIds { get; private set; } = documentRoleIds;
    public TypeSettings TypeSettings { get; private set; } = typeSettings;
}
