using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.Orders;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters.Orders;

internal static class SearchDocumentsQuerySortParametersSortOrderInternalConverter
{
    internal static SearchDocumentSortOrder ToDomain(SearchDocumentsQuerySortParametersSortOrderInternal sortOrder)
    {
        SearchDocumentSortOrder result = sortOrder switch
        {
            SearchDocumentsQuerySortParametersSortOrderInternal.Ascending => SearchDocumentSortOrder.Ascending,

            SearchDocumentsQuerySortParametersSortOrderInternal.Descending => SearchDocumentSortOrder.Descending,

            _ => throw new ArgumentTypeOutOfRangeException(sortOrder)
        };

        return result;
    }
}
