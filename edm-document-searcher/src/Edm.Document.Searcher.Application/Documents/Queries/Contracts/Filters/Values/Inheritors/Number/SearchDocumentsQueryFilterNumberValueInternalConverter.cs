using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Inheritors.Number;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Number;

internal static class SearchDocumentsQueryFilterNumberValueInternalConverter
{
    internal static SearchDocumentsQueryFilterNumberValue ToDomain(SearchDocumentsQueryFilterNumberValueInternal value)
    {
        Number<SearchDocumentsQueryFilter> number = NumberConverterFrom<SearchDocumentsQueryFilter>.From(value.Value);

        var result = new SearchDocumentsQueryFilterNumberValue(number);

        return result;
    }
}
