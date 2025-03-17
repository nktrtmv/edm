using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.Orders;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters.ValuesTypes;

namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.SortParameters;

public sealed class SearchDocumentSortParameters
{
    public SearchDocumentSortParameters(int registryRoleId, SearchDocumentSortOrder sortOrder, SearchDocumentSortValueType sortValueType)
    {
        RegistryRoleId = registryRoleId;
        SortOrder = sortOrder;
        SortValueType = sortValueType;
    }

    public int RegistryRoleId { get; }
    public SearchDocumentSortOrder SortOrder { get; }
    public SearchDocumentSortValueType SortValueType { get; }
}
