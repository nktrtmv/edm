using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Contracts.Roles;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.Roles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get;

public sealed class GetDocumentRegistryRolesService
{
    public GetDocumentRegistryRolesService(IDocumentsRegistryRolesClient roles)
    {
        Roles = roles;
    }

    private IDocumentsRegistryRolesClient Roles { get; }

    public async Task<GetDocumentRegistryRolesQueryBffResponse> GetAll(
        GetDocumentRegistryRolesQueryBff request,
        CancellationToken cancellationToken)
    {
        DocumentRegistryRoleExternal[] response = await Roles.Get(request.DomainId, cancellationToken);

        DocumentRegistryRoleBff[] roles = response.Select(DocumentRegistryRoleBffConverter.FromExternal).ToArray();

        var result = new GetDocumentRegistryRolesQueryBffResponse
        {
            Roles = CollectionQueryResponseConverter.ToBff(roles)
        };

        return result;
    }
}
