using Edm.Document.Classifier.Domain.ValueObjects.DocumentDomains;
using Edm.Document.Classifier.ExternalServices.DocumentsSearchers.Searches.Factories.Queries.Contracts.SortParameters;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentsSearchers.Searches.Factories.Queries;

internal static class SearchDocumentsQueryFactory
{
    internal static SearchDocumentsQuery CreateFrom(int limit, int skip, params SearchDocumentsQueryFilter[] filters)
    {
        var sortParameters = SearchDocumentsQuerySortParametersFactory.CreateNew();

        var result = new SearchDocumentsQuery
        {
            DomainId = DomainId.Contracts.Value,
            Filters = { filters },
            SortParameters = sortParameters,
            Limit = limit,
            Skip = skip
        };

        return result;
    }
}
