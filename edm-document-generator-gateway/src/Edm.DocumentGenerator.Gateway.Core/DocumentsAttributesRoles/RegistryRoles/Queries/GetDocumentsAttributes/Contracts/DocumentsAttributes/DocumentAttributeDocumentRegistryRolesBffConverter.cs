using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts.DocumentsAttributes;

internal static class DocumentAttributeDocumentRegistryRolesBffConverter
{
    internal static DocumentAttributeDocumentRegistryRolesBff FromExternal(DocumentAttributeDocumentRegistryRolesExternal attributeRoles)
    {
        var attribute = DocumentAttributeTypeBffConverter.FromExternal(attributeRoles.Attribute);

        DocumentRegistryRoleBff[] roles = attributeRoles.Roles.Select(DocumentRegistryRoleBffConverter.FromExternal).ToArray();

        var result = new DocumentAttributeDocumentRegistryRolesBff(attribute, roles);

        return result;
    }
}
