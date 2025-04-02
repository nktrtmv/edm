using Edm.Document.Searcher.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;

internal static class SearchDocumentsQueryFilterDateValueBffConverter
{
    internal static SearchDocumentsQueryFilterValue ToDto(SearchDocumentsQueryFilterDateValueBff filterValue)
    {
        var value = Timestamp.FromDateTime(filterValue.Value);

        var asDate = new SearchDocumentsQueryFilterDateValue
        {
            Value = value
        };

        var result = new SearchDocumentsQueryFilterValue
        {
            AsDate = asDate
        };

        return result;
    }
}
