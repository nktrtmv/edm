using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Contains;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Match;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Inheritors.Range;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.Filters.Values;

using Google.Protobuf.Collections;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.Filters;

internal static class SearchDocumentsQueryFilterToInternalConverter
{
    internal static SearchDocumentsQueryFilterInternal ToInternal(SearchDocumentsQueryFilter filter)
    {
        int[] registryRolesIds = filter.RegistryRolesIds.ToArray();

        SearchDocumentsQueryFilterInternal result = filter.ValueCase switch
        {
            SearchDocumentsQueryFilter.ValueOneofCase.Contains => ToContains(registryRolesIds, filter.Contains),
            SearchDocumentsQueryFilter.ValueOneofCase.Match => ToMatch(registryRolesIds, filter.Match),
            SearchDocumentsQueryFilter.ValueOneofCase.Range => ToRange(registryRolesIds, filter.Range),
            _ => throw new ArgumentTypeOutOfRangeException(filter.ValueCase)
        };

        return result;
    }

    private static SearchDocumentsQueryContainsFilterInternal ToContains(
        int[] registryRolesIds,
        SearchDocumentsQueryContainsFilter filter)
    {
        RepeatedField<SearchDocumentsQueryFilterValue> values = filter.Values;

        SearchDocumentsQueryFilterValueInternal[] valuesInternal = values.Select(SearchDocumentsQueryFilterValueToInternalConverter.ToInternal).ToArray();

        var result = new SearchDocumentsQueryContainsFilterInternal(registryRolesIds, valuesInternal);

        return result;
    }

    private static SearchDocumentsQueryMatchFilterInternal ToMatch(
        int[] registryRolesIds,
        SearchDocumentsQueryMatchFilter filter)
    {
        SearchDocumentsQueryFilterValueInternal[] values =
            filter.Values.Select(SearchDocumentsQueryFilterValueToInternalConverter.ToInternal).ToArray();

        var result = new SearchDocumentsQueryMatchFilterInternal(registryRolesIds, values);

        return result;
    }

    private static SearchDocumentsQueryRangeFilterInternal ToRange(
        int[] registryRolesIds,
        SearchDocumentsQueryRangeFilter filter)
    {
        SearchDocumentsQueryFilterValueInternal startValue = SearchDocumentsQueryFilterValueToInternalConverter.ToInternal(filter.StartValue);
        SearchDocumentsQueryFilterValueInternal endValue = SearchDocumentsQueryFilterValueToInternalConverter.ToInternal(filter.EndValue);

        var result = new SearchDocumentsQueryRangeFilterInternal(registryRolesIds, startValue, endValue);

        return result;
    }
}
