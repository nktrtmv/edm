using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Reference;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Reference;

internal static class SearchDocumentsQueryFilterReferenceValueInternalConverter
{
    internal static SearchDocumentsQueryFilterReferenceValue ToDomain(SearchDocumentsQueryFilterReferenceValueInternal value)
    {
        var result = new SearchDocumentsQueryFilterReferenceValue(value.Value);

        return result;
    }
}
