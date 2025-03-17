using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;

public sealed class GetAllDocumentsQueryBffResponse
{
    public required CollectionQueryResponse<GetAllDocumentsQueryResponseDocumentBff> Documents { get; init; }
}
