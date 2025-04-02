using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Inheritors;
using Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters.Inheritors;

namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.Queries.Converters.Filters;

internal static class SearchDocumentsQueryFiltersDbConverter
{
    internal static string FromDomain(SearchDocumentsQueryFilter[] filters)
    {
        string[] filtersDb = filters.Where(x => x.RegistryRolesIds.Length > 0).Select(FromDomain).ToArray();

        string result = (filtersDb.Length != 0 ? " AND " : string.Empty) + string.Join(" AND ", filtersDb);

        return result;
    }

    private static string FromDomain(SearchDocumentsQueryFilter filter)
    {
        string filterDb = filter switch
        {
            SearchDocumentsQueryContainsFilter f =>
                SearchDocumentsQueryContainsFilterDbConverter.FromDomain(f),

            SearchDocumentsQueryMatchFilter f =>
                SearchDocumentsQueryMatchFilterDbConverter.FromDomain(f),

            SearchDocumentsQueryRangeFilter f =>
                SearchDocumentsQueryRangeFilterDbConverter.FromDomain(f),

            _ => throw new ArgumentTypeOutOfRangeException(filter)
        };

        var result = $"({filterDb})";

        return result;
    }
}
