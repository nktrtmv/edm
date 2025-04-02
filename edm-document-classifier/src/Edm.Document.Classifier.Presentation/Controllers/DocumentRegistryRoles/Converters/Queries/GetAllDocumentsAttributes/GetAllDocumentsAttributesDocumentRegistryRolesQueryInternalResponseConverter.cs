using Edm.Document.Classifier.Application.DocumentRegistryRoles.Queries.GetAllDocumentsAttributes.Contracts;
using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes.Converters.DocumentsAttributes;

namespace Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles.Converters.Queries.GetAllDocumentsAttributes;

internal static class GetAllDocumentsAttributesDocumentRegistryRolesQueryInternalResponseConverter
{
    internal static GetAllDocumentsAttributesDocumentRegistryRolesQueryResponse ToDto(GetDomainRegistryRolesInternalResponse response)
    {
        DocumentAttributeDocumentRegistryRolesDto[] documentsAttributesRoles =
            DocumentAttributeDocumentRegistryRolesInternalConverter.ToDto(response.RegistryRoles, true).ToArray();

        var result = new GetAllDocumentsAttributesDocumentRegistryRolesQueryResponse
        {
            DocumentsAttributesRoles = { documentsAttributesRoles }
        };

        return result;
    }
}
