using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Date;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Date;

internal static class SearchDocumentsQueryFilterDateValueInternalConverter
{
    internal static SearchDocumentsQueryFilterDateValue ToDomain(SearchDocumentsQueryFilterDateValueInternal value)
    {
        UtcDateTime<SearchDocumentsQueryFilter> date = UtcDateTimeConverterFrom<SearchDocumentsQueryFilter>.From(value.Value);

        var result = new SearchDocumentsQueryFilterDateValue(date);

        return result;
    }
}
