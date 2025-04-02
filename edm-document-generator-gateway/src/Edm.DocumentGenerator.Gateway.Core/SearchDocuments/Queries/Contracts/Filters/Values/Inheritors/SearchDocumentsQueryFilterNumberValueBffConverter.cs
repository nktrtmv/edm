using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

internal static class SearchDocumentsQueryFilterNumberValueBffConverter
{
    internal static SearchDocumentsQueryFilterValue ToDto(SearchDocumentsQueryFilterNumberValueBff filterValue)
    {
        var asNumber = new SearchDocumentsQueryFilterNumberValue
        {
            Value = filterValue.Value
        };

        var result = new SearchDocumentsQueryFilterValue
        {
            AsNumber = asNumber
        };

        return result;
    }
}
