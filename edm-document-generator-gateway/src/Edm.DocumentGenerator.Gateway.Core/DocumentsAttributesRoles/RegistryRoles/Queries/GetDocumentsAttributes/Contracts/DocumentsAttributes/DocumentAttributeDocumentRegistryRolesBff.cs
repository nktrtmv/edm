using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts.DocumentsAttributes;

public sealed class DocumentAttributeDocumentRegistryRolesBff
{
    public DocumentAttributeDocumentRegistryRolesBff(DocumentAttributeTypeBff attribute, DocumentRegistryRoleBff[] roles)
    {
        Attribute = attribute;
        Roles = roles;
    }

    public DocumentAttributeTypeBff Attribute { get; }
    public DocumentRegistryRoleBff[] Roles { get; }
}
