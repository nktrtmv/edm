using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;

internal static class SearchDocumentsQueryContainsFilterBffConverter
{
    internal static SearchDocumentsQueryFilter ToDto(
        SearchDocumentsQueryContainsFilterBff filter,
        DomainRoles domainRoles)
    {
        var registryRolesIds = filter.RegistryRolesIds.Select(domainRoles.GetRegistryRoleIdByName).ToArray();

        var valuesDto = filter.Values.Select(SearchDocumentsQueryFilterValueInternalConverter.ToDomain).ToArray();

        var contains = new SearchDocumentsQueryContainsFilter
        {
            Values = { valuesDto }
        };

        var result = new SearchDocumentsQueryFilter
        {
            RegistryRolesIds = { registryRolesIds },
            Contains = contains
        };

        return result;
    }
}
