using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Boolean;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Boolean;

internal static class SearchDocumentsQueryFilterBooleanValueInternalConverter
{
    internal static SearchDocumentsQueryFilterBooleanValue ToDomain(SearchDocumentsQueryFilterBooleanValueInternal value)
    {
        var result = new SearchDocumentsQueryFilterBooleanValue(value.Value);

        return result;
    }
}
