using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

internal static class SearchDocumentsQueryFilterBooleanValueBffConverter
{
    internal static SearchDocumentsQueryFilterValue ToDto(SearchDocumentsQueryFilterBooleanValueBff filterValue)
    {
        var asBoolean = new SearchDocumentsQueryFilterBooleanValue
        {
            Value = filterValue.Value
        };

        var result = new SearchDocumentsQueryFilterValue
        {
            AsBoolean = asBoolean
        };

        return result;
    }
}
