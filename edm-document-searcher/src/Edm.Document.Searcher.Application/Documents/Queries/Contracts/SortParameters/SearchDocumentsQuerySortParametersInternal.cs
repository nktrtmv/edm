using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters.Orders;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;

public sealed class SearchDocumentsQuerySortParametersInternal
{
    public SearchDocumentsQuerySortParametersInternal(
        int registryRoleId,
        SearchDocumentsQuerySortParametersSortOrderInternal sortOrder)
    {
        RegistryRoleId = registryRoleId;
        SortOrder = sortOrder;
    }

    public int RegistryRoleId { get; }
    public SearchDocumentsQuerySortParametersSortOrderInternal SortOrder { get; }
}
