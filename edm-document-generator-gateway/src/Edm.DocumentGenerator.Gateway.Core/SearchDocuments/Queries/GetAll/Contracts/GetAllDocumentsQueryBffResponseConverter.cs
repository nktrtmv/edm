using Edm.DocumentGenerator.Gateway.Core.Contracts.CollectionQueryResponses;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts.Contracts.Documents;
using Edm.DocumentGenerator.Gateway.GenericSubdomain;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.GetAll.Contracts;

internal static class GetAllDocumentsQueryBffResponseConverter
{
    internal static GetAllDocumentsQueryBffResponse FromInternal(GetAllDocumentsQueryResponseDocumentBff[] documents)
    {
        CollectionQueryResponse<GetAllDocumentsQueryResponseDocumentBff> documentsCollection =
            CollectionQueryResponseConverter.ToBff(documents);

        var result = new GetAllDocumentsQueryBffResponse
        {
            Documents = documentsCollection
        };

        return result;
    }
}
