using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Contains;

internal static class SearchDocumentsQueryContainsFilterInternalConverter
{
    internal static SearchDocumentsQueryContainsFilter ToDomain(SearchDocumentsQueryContainsFilterInternal filter)
    {
        int[] registryRolesIds = filter.RegistryRolesIds.ToArray();

        SearchDocumentsQueryFilterValue[] values = filter.Values.Select(SearchDocumentsQueryFilterValueInternalConverter.ToDomain).ToArray();

        var result = new SearchDocumentsQueryContainsFilter(registryRolesIds, values);

        return result;
    }
}
