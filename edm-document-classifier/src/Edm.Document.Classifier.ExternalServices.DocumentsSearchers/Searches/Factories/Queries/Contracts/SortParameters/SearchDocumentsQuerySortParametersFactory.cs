using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Classifier.ExternalServices.DocumentsSearchers.Searches.Factories.Queries.Contracts.SortParameters;

internal static class SearchDocumentsQuerySortParametersFactory
{
    private const int ContractsCreatedAtRole = 4;

    internal static SearchDocumentsQuerySortParameters CreateNew()
    {
        const SearchDocumentsQuerySortParametersSortOrder sortOrder = SearchDocumentsQuerySortParametersSortOrder.Descending;

        var result = new SearchDocumentsQuerySortParameters
        {
            RegistryRoleId = ContractsCreatedAtRole,
            SortOrder = sortOrder
        };

        return result;
    }
}
