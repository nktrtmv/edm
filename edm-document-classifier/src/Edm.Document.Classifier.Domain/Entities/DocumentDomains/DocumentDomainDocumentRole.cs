using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;

namespace Edm.Document.Classifier.Domain.Entities.DocumentDomains;

public sealed class DocumentDomainDocumentRole(
    DocumentRoleId id,
    DocumentRoleName documentRoleName,
    DisplayName displayName,
    List<AllowedAttributeCondition> allowedAttributesConditions)
{
    public DocumentRoleId Id { get; private set; } = id;

    public DocumentRoleName Name { get; private set; } = documentRoleName;

    public DisplayName DisplayName { get; private set; } = displayName;

    public List<AllowedAttributeCondition> AllowedAttributesConditions { get; private set; } = allowedAttributesConditions;
}
