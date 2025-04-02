using Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Contracts;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsAttributesRoles.DocumentsRoles.Queries.GetAll.Contracts;

public sealed class GetAllDocumentsAttributesDocumentsRolesQueryBffResponse
{
    public required CollectionQueryResponse<DocumentsAttributesDocumentsRolesBff> DocumentsAttributesDocumentsRoles { get; init; }
}
