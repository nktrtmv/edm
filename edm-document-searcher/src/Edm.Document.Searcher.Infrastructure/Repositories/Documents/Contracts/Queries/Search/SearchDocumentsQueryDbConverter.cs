using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Queries.Search;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.SortParameters;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Search;

internal static class SearchDocumentsQueryDbConverter
{
    internal static SearchDocumentsQueryDb FromDomain(SearchDocumentsQuery query)
    {
        string filters = SearchDocumentsQueryFiltersDbConverter.FromDomain(query.Filters);

        string sortParameters = SearchDocumentSortParametersDbConverter.FromDomain(query.SortParameters);

        var result = new SearchDocumentsQueryDb(query.DomainId.Value, filters, sortParameters, query.Limit, query.Skip);

        return result;
    }
}
