using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.String;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.String;

internal static class SearchDocumentsQueryFilterStringValueInternalConverter
{
    internal static SearchDocumentsQueryFilterStringValue ToDomain(SearchDocumentsQueryFilterStringValueInternal value)
    {
        var result = new SearchDocumentsQueryFilterStringValue(value.Value);

        return result;
    }
}
