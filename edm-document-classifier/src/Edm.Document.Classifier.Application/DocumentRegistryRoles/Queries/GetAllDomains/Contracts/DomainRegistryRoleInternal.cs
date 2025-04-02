using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;
using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains.Roles.Types;
using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts;

public sealed record DomainRegistryRoleInternal(
    int Id,
    string DisplayName,
    string Name,
    DocumentRegistryRoleTypeInternal Type,
    DocumentRegistryRoleKind Kind,
    string? SystemName,
    RegistrySettingsInternal RegistrySettings,
    FilterSettingsInternal FilterSettings,
    List<AllowedAttributeConditionInternal> AdditionAllowedAttributesConditions);
