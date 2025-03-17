using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Inheritors;

internal static class SearchDocumentsQueryMatchFilterBffConverter
{
    internal static SearchDocumentsQueryFilter ToDto(
        SearchDocumentsQueryMatchFilterBff filter,
        DomainRoles domainRoles)
    {
        var registryRolesIds = filter.RegistryRolesIds.Select(domainRoles.GetRegistryRoleIdByName).ToArray();

        var values =
            filter.Values.Select(SearchDocumentsQueryFilterValueInternalConverter.ToDomain).ToArray();

        var match = new SearchDocumentsQueryMatchFilter
        {
            Values = { values }
        };

        var result = new SearchDocumentsQueryFilter
        {
            RegistryRolesIds = { registryRolesIds },
            Match = match
        };

        return result;
    }
}
