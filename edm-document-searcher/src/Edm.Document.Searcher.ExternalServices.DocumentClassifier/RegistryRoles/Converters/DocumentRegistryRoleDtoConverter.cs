using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Domains.Roles.Types;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Converters.Types;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles.Converters;

internal static class DocumentRegistryRoleDtoConverter
{
    internal static DocumentRegistryRoleExternal ToExternal(DocumentAttributeDocumentRegistryRolesDto model)
    {
        DocumentRegistryRoleDto role = model.Roles.First();

        DocumentRegistryRoleTypeExternal type = DocumentRegistryRoleTypeExternalFromDomainConverter.FromDto(role.Type);

        var result = new DocumentRegistryRoleExternal(role.Id, role.DisplayName, type, (int)role.Kind, role.SystemName);

        return result;
    }
}
