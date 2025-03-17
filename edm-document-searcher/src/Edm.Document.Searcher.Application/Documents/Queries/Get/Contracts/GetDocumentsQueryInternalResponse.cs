using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts;

public sealed class GetDocumentsQueryInternalResponse
{
    public GetDocumentsQueryInternalResponse(GetDocumentsQueryInternalResponseSearchDocument[] documents)
    {
        Documents = documents;
    }

    public GetDocumentsQueryInternalResponseSearchDocument[] Documents { get; }
}
