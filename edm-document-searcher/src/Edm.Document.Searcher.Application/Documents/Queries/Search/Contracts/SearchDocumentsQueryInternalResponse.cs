using Edm.Document.Searcher.Application.Documents.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;

public sealed class SearchDocumentsQueryInternalResponse
{
    public SearchDocumentsQueryInternalResponse(Id<SearchDocumentInternal>[] documentsIds)
    {
        DocumentsIds = documentsIds;
    }

    public Id<SearchDocumentInternal>[] DocumentsIds { get; }
}
