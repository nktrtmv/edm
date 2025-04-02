using Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Search;

internal static class SearchDocumentsQueryResponseConverter
{
    internal static SearchDocumentsQueryResponse FromInternal(SearchDocumentsQueryInternalResponse response)
    {
        string[] documentsIds = response.DocumentsIds.Select(IdConverterTo.ToString).ToArray();

        var result = new SearchDocumentsQueryResponse
        {
            DocumentsIds = { documentsIds }
        };

        return result;
    }
}
