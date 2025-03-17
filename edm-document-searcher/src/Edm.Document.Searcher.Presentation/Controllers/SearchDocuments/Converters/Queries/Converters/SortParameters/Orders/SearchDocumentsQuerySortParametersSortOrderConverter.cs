using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters.Orders;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.SortParameters.Orders;

internal static class SearchDocumentsQuerySortParametersSortOrderConverter
{
    internal static SearchDocumentsQuerySortParametersSortOrderInternal ToInternal(SearchDocumentsQuerySortParametersSortOrder sortOrder)
    {
        SearchDocumentsQuerySortParametersSortOrderInternal result = sortOrder switch
        {
            SearchDocumentsQuerySortParametersSortOrder.Ascending =>
                SearchDocumentsQuerySortParametersSortOrderInternal.Ascending,

            SearchDocumentsQuerySortParametersSortOrder.Descending =>
                SearchDocumentsQuerySortParametersSortOrderInternal.Descending,

            _ => throw new ArgumentTypeOutOfRangeException(sortOrder)
        };

        return result;
    }
}
