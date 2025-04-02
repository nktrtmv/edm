using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;
using Edm.Document.Searcher.Application.Documents.Queries.Search.Contracts;
using Edm.Document.Searcher.Domain.Documents;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.Filters;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.SortParameters;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Search;

internal static class SearchDocumentsQueryConverter
{
    internal static SearchDocumentsQueryInternal ToInternal(SearchDocumentsQuery query)
    {
        SearchDocumentsQueryFilterInternal[] filters =
            query.Filters.Select(SearchDocumentsQueryFilterToInternalConverter.ToInternal).ToArray();

        SearchDocumentsQuerySortParametersInternal sortParameters =
            SearchDocumentsQuerySortParametersConverter.ToInternal(query.SortParameters);

        string domainId = DomainIdHelper.GetDomainIdOrSetDefault(query.DomainId);

        var result = new SearchDocumentsQueryInternal(domainId, filters, sortParameters, query.Limit, query.Skip);

        return result;
    }
}
