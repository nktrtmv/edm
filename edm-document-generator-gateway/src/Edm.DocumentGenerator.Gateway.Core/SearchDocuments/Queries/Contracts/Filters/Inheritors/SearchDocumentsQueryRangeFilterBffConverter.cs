using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;

internal static class SearchDocumentsQueryRangeFilterBffConverter
{
    internal static SearchDocumentsQueryFilter ToDto(
        SearchDocumentsQueryRangeFilterBff filter,
        DomainRoles domainRoles)
    {
        var registryRolesIds = filter.RegistryRolesIds.Select(domainRoles.GetRegistryRoleIdByName).ToArray();

        var startValue = SearchDocumentsQueryFilterValueInternalConverter.ToDomain(filter.StartValue);

        var endValue = SearchDocumentsQueryFilterValueInternalConverter.ToDomain(filter.EndValue);

        var range = new SearchDocumentsQueryRangeFilter
        {
            StartValue = startValue,
            EndValue = endValue
        };

        var result = new SearchDocumentsQueryFilter
        {
            RegistryRolesIds = { registryRolesIds },
            Range = range
        };

        return result;
    }
}
