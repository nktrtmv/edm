using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters.SortOrders;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters;

internal static class SearchDocumentsQuerySortParametersBffConverter
{
    private const int CreatedAtRole = 4;

    internal static SearchDocumentsQuerySortParameters ToDto(
        SearchDocumentsQuerySortParametersBff? sortParameters,
        DomainRoles domainRoles)
    {
        var registryRoleId = !string.IsNullOrWhiteSpace(sortParameters?.RegistryRoleId)
            ? domainRoles.GetRegistryRoleIdByName(sortParameters.RegistryRoleId)
            : CreatedAtRole;

        var sortOrder = sortParameters?.SortOrder switch
        {
            null => SearchDocumentsQuerySortParametersSortOrder.Descending,
            SearchDocumentsQuerySortParametersSortOrderBff.Ascending => SearchDocumentsQuerySortParametersSortOrder.Ascending,
            SearchDocumentsQuerySortParametersSortOrderBff.Descending => SearchDocumentsQuerySortParametersSortOrder.Descending,
            _ => throw new ArgumentTypeOutOfRangeException(sortParameters.SortOrder)
        };

        var result = new SearchDocumentsQuerySortParameters
        {
            RegistryRoleId = registryRoleId,
            SortOrder = sortOrder
        };

        return result;
    }
}
