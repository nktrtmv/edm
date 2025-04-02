using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Contains;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Match;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Range;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;

internal static class SearchDocumentsQueryFilterInternalConverter
{
    internal static SearchDocumentsQueryFilter ToDomain(SearchDocumentsQueryFilterInternal filter)
    {
        SearchDocumentsQueryFilter result = filter switch
        {
            SearchDocumentsQueryContainsFilterInternal f => SearchDocumentsQueryContainsFilterInternalConverter.ToDomain(f),
            SearchDocumentsQueryMatchFilterInternal f => SearchDocumentsQueryMatchFilterInternalConverter.ToDomain(f),
            SearchDocumentsQueryRangeFilterInternal f => SearchDocumentsQueryRangeFilterInternalConverter.ToDomain(f),
            _ => throw new ArgumentTypeOutOfRangeException(filter)
        };

        return result;
    }
}
