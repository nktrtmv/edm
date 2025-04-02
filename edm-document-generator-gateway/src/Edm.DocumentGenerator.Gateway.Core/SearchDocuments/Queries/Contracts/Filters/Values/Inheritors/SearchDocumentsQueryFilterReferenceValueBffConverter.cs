using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

internal static class SearchDocumentsQueryFilterReferenceValueBffConverter
{
    internal static SearchDocumentsQueryFilterValue ToDto(SearchDocumentsQueryFilterReferenceValueBff filterValue)
    {
        var asReference = new SearchDocumentsQueryFilterReferenceValue
        {
            Value = filterValue.Value
        };

        var result = new SearchDocumentsQueryFilterValue
        {
            AsReference = asReference
        };

        return result;
    }
}
