using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Boolean;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Date;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Number;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Reference;
using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.String;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.SearchDocuments.Converters.Queries.Converters.Filters.Values;

internal static class SearchDocumentsQueryFilterValueToInternalConverter
{
    internal static SearchDocumentsQueryFilterValueInternal ToInternal(SearchDocumentsQueryFilterValue value)
    {
        SearchDocumentsQueryFilterValueInternal result = value.ValueCase switch
        {
            SearchDocumentsQueryFilterValue.ValueOneofCase.AsBoolean => ToBoolean(value.AsBoolean),
            SearchDocumentsQueryFilterValue.ValueOneofCase.AsDate => ToDate(value.AsDate),
            SearchDocumentsQueryFilterValue.ValueOneofCase.AsNumber => ToNumber(value.AsNumber),
            SearchDocumentsQueryFilterValue.ValueOneofCase.AsReference => ToReference(value.AsReference),
            SearchDocumentsQueryFilterValue.ValueOneofCase.AsString => ToString(value.AsString),
            _ => throw new ArgumentTypeOutOfRangeException(value.ValueCase)
        };

        return result;
    }

    private static SearchDocumentsQueryFilterBooleanValueInternal ToBoolean(SearchDocumentsQueryFilterBooleanValue filter)
    {
        var result = new SearchDocumentsQueryFilterBooleanValueInternal(filter.Value);

        return result;
    }

    private static SearchDocumentsQueryFilterDateValueInternal ToDate(SearchDocumentsQueryFilterDateValue filter)
    {
        UtcDateTime<SearchDocumentsQueryFilterInternal> value = UtcDateTimeConverterFrom<SearchDocumentsQueryFilterInternal>.FromTimestamp(filter.Value);

        var result = new SearchDocumentsQueryFilterDateValueInternal(value);

        return result;
    }

    private static SearchDocumentsQueryFilterNumberValueInternal ToNumber(SearchDocumentsQueryFilterNumberValue filter)
    {
        Number<SearchDocumentsQueryFilterInternal> value = NumberConverterFrom<SearchDocumentsQueryFilterInternal>.FromLong(filter.Value);

        var result = new SearchDocumentsQueryFilterNumberValueInternal(value);

        return result;
    }

    private static SearchDocumentsQueryFilterReferenceValueInternal ToReference(SearchDocumentsQueryFilterReferenceValue filter)
    {
        var result = new SearchDocumentsQueryFilterReferenceValueInternal(filter.Value);

        return result;
    }

    private static SearchDocumentsQueryFilterStringValueInternal ToString(SearchDocumentsQueryFilterStringValue filter)
    {
        var result = new SearchDocumentsQueryFilterStringValueInternal(filter.Value);

        return result;
    }
}
