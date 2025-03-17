using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

internal static class SearchDocumentsQueryFilterStringValueBffConverter
{
    internal static SearchDocumentsQueryFilterValue ToDto(SearchDocumentsQueryFilterStringValueBff filterValue)
    {
        var asString = new SearchDocumentsQueryFilterStringValue
        {
            Value = filterValue.Value
        };

        var result = new SearchDocumentsQueryFilterValue
        {
            AsString = asString
        };

        return result;
    }
}
