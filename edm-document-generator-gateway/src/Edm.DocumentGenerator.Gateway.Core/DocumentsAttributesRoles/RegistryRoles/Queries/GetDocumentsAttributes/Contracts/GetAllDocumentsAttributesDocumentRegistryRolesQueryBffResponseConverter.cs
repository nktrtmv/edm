using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts.DocumentsAttributes;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles.Contracts.DocumentsAttributes;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts;

internal static class GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponseConverter
{
    internal static GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponse FromExternal(DocumentAttributeDocumentRegistryRolesExternal[] response)
    {
        DocumentAttributeDocumentRegistryRolesBff[] documentsAttributesRoles =
            response.Select(DocumentAttributeDocumentRegistryRolesBffConverter.FromExternal).ToArray();

        var result = new GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponse
        {
            DocumentsAttributesRoles = CollectionQueryResponseConverter.ToBff(documentsAttributesRoles)
        };

        return result;
    }
}
