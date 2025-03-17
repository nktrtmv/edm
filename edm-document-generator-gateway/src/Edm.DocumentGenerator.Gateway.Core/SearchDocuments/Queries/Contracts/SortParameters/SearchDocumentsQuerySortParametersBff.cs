using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters.SortOrders;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.SortParameters;

public sealed class SearchDocumentsQuerySortParametersBff
{
    public string? RegistryRoleId { get; init; }
    public SearchDocumentsQuerySortParametersSortOrderBff? SortOrder { get; init; }
}
