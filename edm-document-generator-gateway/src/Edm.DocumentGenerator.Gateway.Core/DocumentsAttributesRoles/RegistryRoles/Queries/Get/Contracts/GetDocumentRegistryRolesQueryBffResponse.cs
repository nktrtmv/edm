using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get.Contracts;

public sealed class GetDocumentRegistryRolesQueryBffResponse
{
    public required CollectionQueryResponse<DocumentRegistryRoleBff> Roles { get; init; }
}
