using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts;

internal static class DocumentsAttributesDocumentsRolesBffConverter
{
    internal static DocumentsAttributesDocumentsRolesBff FromDto(DocumentAttributeTypeExternal typeExternal, DocumentRoleExternal[] roles)
    {
        var type = DocumentAttributeTypeBffConverter.FromDto(typeExternal);

        DocumentAttributeDocumentRoleBff[] items = roles.Select(x => new DocumentAttributeDocumentRoleBff(x.Name, x.Id, x.Display)).ToArray();

        var result = new DocumentsAttributesDocumentsRolesBff
        {
            AttributeType = type,
            Roles = items
        };

        return result;
    }
}
