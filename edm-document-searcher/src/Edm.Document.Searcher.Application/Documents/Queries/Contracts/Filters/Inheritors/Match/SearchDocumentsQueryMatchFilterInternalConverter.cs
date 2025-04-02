using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Match;

internal static class SearchDocumentsQueryMatchFilterInternalConverter
{
    internal static SearchDocumentsQueryMatchFilter ToDomain(SearchDocumentsQueryMatchFilterInternal filter)
    {
        int[] registryRolesIds = filter.RegistryRolesIds;

        SearchDocumentsQueryFilterValue[] values =
            filter.Values.Select(SearchDocumentsQueryFilterValueInternalConverter.ToDomain).ToArray();

        var result = new SearchDocumentsQueryMatchFilter(registryRolesIds, values);

        return result;
    }
}
