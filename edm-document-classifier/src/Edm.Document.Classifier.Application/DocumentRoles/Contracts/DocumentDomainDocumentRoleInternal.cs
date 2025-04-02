using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDomains.Contracts.Domains;

namespace Edm.Document.Classifier.Application.DocumentRoles.Contracts;

public sealed record DocumentDomainDocumentRoleInternal(
    int Id,
    string Name,
    string Display,
    List<AllowedAttributeConditionInternal> AllowedAttributesConditions);
