using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Queries.GetAll.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Queries.GetAll;

public sealed class GetAllDocumentsAttributesRolesService(IDocumentsRolesClient rolesClient)
{
    public async Task<GetAllDocumentsAttributesDocumentsRolesQueryBffResponse> GetAllDocumentsAttributesDocumentsRoles(
        GetAllDocumentsAttributesDocumentsRolesQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        var response = await rolesClient.GetAll(queryBff.DomainId, cancellationToken);
        DocumentsAttributesDocumentsRolesBff[] documentsAttributesDocumentsRoles =
            response.Select(x => DocumentsAttributesDocumentsRolesBffConverter.FromDto(x.type, x.roles)).ToArray();

        var result = new GetAllDocumentsAttributesDocumentsRolesQueryBffResponse
        {
            DocumentsAttributesDocumentsRoles = CollectionQueryResponseConverter.ToBff(documentsAttributesDocumentsRoles)
        };

        return result;
    }
}
