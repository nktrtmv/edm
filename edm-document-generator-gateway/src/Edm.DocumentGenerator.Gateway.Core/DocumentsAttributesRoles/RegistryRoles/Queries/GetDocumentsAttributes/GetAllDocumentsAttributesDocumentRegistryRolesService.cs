using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes;

public sealed class GetAllDocumentsAttributesDocumentRegistryRolesService
{
    public GetAllDocumentsAttributesDocumentRegistryRolesService(IDocumentsRegistryRolesClient roles)
    {
        Roles = roles;
    }

    private IDocumentsRegistryRolesClient Roles { get; }

    public async Task<GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponse> Get(
        GetAllDocumentsAttributesDocumentRegistryRolesQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        DocumentAttributeDocumentRegistryRolesExternal[] response = await Roles.GetDocumentsAttributes(queryBff.DomainId, cancellationToken);

        var result =
            GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponseConverter.FromExternal(response);

        return result;
    }
}
