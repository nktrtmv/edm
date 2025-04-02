using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.Ids;
using Edm.Document.Classifier.Domain.Entities.DocumentReferences.ValueObjects.Types.ValueObjects.SearchKinds;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public sealed class DocumentDomainRegistryRole
{
    private DocumentDomainRegistryRole()
    {
    }

    public RegistryRoleId Id { get; private set; }

    public DocumentRegistryRoleKind Kind { get; private set; }

    public RegistryRoleName Name { get; private set; }

    public DisplayName DisplayName { get; private set; }

    public SystemName? SystemName { get; private set; }

    public FilterSettings FilterSettings { get; private set; }

    public RegistrySettings RegistrySettings { get; private set; }

    public TypeSettings TypeSettings { get; private set; }

    public List<AllowedAttributeCondition> AdditionAllowedAttributesConditions { get; private set; }

    public static DocumentDomainRegistryRole Parse(
        RegistryRoleId id,
        RegistryRoleName name,
        DisplayName displayName,
        DocumentRegistryRoleKind kind,
        SystemName? systemName,
        RegistrySettings registrySettings,
        FilterSettings filterSettings,
        TypeSettings typeSettings,
        List<AllowedAttributeCondition> additionAllowedAttributesConditions,
        Dictionary<DocumentReferenceTypeId, DocumentReferenceSearchKind> searchTypeByReferenceId)
    {
        if (typeSettings is ReferenceTypeSettings)
        {
            filterSettings.SetAllowMultipleValues(true);
        }

        var result = new DocumentDomainRegistryRole
        {
            Id = id,
            Kind = kind,
            Name = name,
            DisplayName = displayName,
            SystemName = systemName,
            FilterSettings = filterSettings,
            RegistrySettings = registrySettings,
            TypeSettings = typeSettings,
            AdditionAllowedAttributesConditions = additionAllowedAttributesConditions,
        };

        return result;
    }
}
