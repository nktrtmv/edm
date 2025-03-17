using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.SortParameters.Orders;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.SortParameters.Orders;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.SortParameters;

internal static class SearchDocumentsQuerySortParametersConverter
{
    internal static SearchDocumentsQuerySortParametersInternal ToInternal(SearchDocumentsQuerySortParameters sortParameters)
    {
        int registryRoleId = sortParameters.RegistryRoleId;

        SearchDocumentsQuerySortParametersSortOrderInternal sortOrder =
            SearchDocumentsQuerySortParametersSortOrderConverter.ToInternal(sortParameters.SortOrder);

        var result = new SearchDocumentsQuerySortParametersInternal(registryRoleId, sortOrder);

        return result;
    }
}
