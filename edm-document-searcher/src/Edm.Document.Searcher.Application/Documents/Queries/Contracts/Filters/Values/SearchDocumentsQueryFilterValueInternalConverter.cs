using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Boolean;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Date;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Number;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Reference;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;

internal static class SearchDocumentsQueryFilterValueInternalConverter
{
    internal static SearchDocumentsQueryFilterValue ToDomain(SearchDocumentsQueryFilterValueInternal value)
    {
        SearchDocumentsQueryFilterValue result = value switch
        {
            SearchDocumentsQueryFilterBooleanValueInternal v => SearchDocumentsQueryFilterBooleanValueInternalConverter.ToDomain(v),
            SearchDocumentsQueryFilterDateValueInternal v => SearchDocumentsQueryFilterDateValueInternalConverter.ToDomain(v),
            SearchDocumentsQueryFilterNumberValueInternal v => SearchDocumentsQueryFilterNumberValueInternalConverter.ToDomain(v),
            SearchDocumentsQueryFilterReferenceValueInternal v => SearchDocumentsQueryFilterReferenceValueInternalConverter.ToDomain(v),
            SearchDocumentsQueryFilterStringValueInternal v => SearchDocumentsQueryFilterStringValueInternalConverter.ToDomain(v),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }
}
