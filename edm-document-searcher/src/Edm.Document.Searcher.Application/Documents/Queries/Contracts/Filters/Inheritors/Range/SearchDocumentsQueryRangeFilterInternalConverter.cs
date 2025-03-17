using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Range;

internal static class SearchDocumentsQueryRangeFilterInternalConverter
{
    internal static SearchDocumentsQueryRangeFilter ToDomain(SearchDocumentsQueryRangeFilterInternal filter)
    {
        int[] registryRolesIds = filter.RegistryRolesIds;

        SearchDocumentsQueryFilterValue startValue = SearchDocumentsQueryFilterValueInternalConverter.ToDomain(filter.StartValue);

        SearchDocumentsQueryFilterValue endValue = SearchDocumentsQueryFilterValueInternalConverter.ToDomain(filter.EndValue);

        var result = new SearchDocumentsQueryRangeFilter(registryRolesIds, startValue, endValue);

        return result;
    }
}
