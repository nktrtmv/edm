using Edm.Document.Classifier.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.DocumentsAttributes.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Roles;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Converters.DocumentsAttributes;

internal static class DocumentAttributeDocumentRegistryRolesExternalConverter
{
    internal static DocumentAttributeDocumentRegistryRolesExternal FromDto(DocumentAttributeDocumentRegistryRolesDto attributeRoles)
    {
        var attribute = DocumentAttributeTypeExternalConverter.FromDto(attributeRoles.Attribute);

        DocumentRegistryRoleExternal[] roles = attributeRoles.Roles.Select(DocumentRegistryRoleDtoConverter.ToExternal).ToArray();

        var result = new DocumentAttributeDocumentRegistryRolesExternal(attribute, roles);

        return result;
    }
}
