using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes.AttributesTypes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;

public interface IDocumentsRolesClient
{
    Task<List<(DocumentAttributeTypeExternal type, DocumentRoleExternal[] roles)>> GetAll(string domainId, CancellationToken cancellationToken);
}
