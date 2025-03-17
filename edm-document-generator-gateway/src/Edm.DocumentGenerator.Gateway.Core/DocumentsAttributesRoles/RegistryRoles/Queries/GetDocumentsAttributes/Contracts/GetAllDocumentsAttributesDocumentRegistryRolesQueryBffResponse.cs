using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts.DocumentsAttributes;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.RegistryRoles.Queries.GetDocumentsAttributes.Contracts;

public sealed class GetAllDocumentsAttributesDocumentRegistryRolesQueryBffResponse
{
    public required CollectionQueryResponse<DocumentAttributeDocumentRegistryRolesBff> DocumentsAttributesRoles { get; init; }
}
