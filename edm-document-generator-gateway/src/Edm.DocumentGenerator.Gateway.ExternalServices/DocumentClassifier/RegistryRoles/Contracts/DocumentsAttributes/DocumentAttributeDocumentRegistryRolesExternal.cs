using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;

public sealed class DocumentAttributeDocumentRegistryRolesExternal
{
    public DocumentAttributeDocumentRegistryRolesExternal(DocumentAttributeTypeExternal attribute, DocumentRegistryRoleExternal[] roles)
    {
        Attribute = attribute;
        Roles = roles;
    }

    public DocumentAttributeTypeExternal Attribute { get; }
    public DocumentRegistryRoleExternal[] Roles { get; }
}
