using Edm.Document.Searcher.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values.Inheritors;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.SearchDocuments.Queries.Contracts.Filters.Values;

internal static class SearchDocumentsQueryFilterValueInternalConverter
{
    internal static SearchDocumentsQueryFilterValue ToDomain(SearchDocumentsQueryFilterValueBff value)
    {
        var result = value switch
        {
            SearchDocumentsQueryFilterBooleanValueBff v => SearchDocumentsQueryFilterBooleanValueBffConverter.ToDto(v),
            SearchDocumentsQueryFilterDateValueBff v => SearchDocumentsQueryFilterDateValueBffConverter.ToDto(v),
            SearchDocumentsQueryFilterNumberValueBff v => SearchDocumentsQueryFilterNumberValueBffConverter.ToDto(v),
            SearchDocumentsQueryFilterReferenceValueBff v => SearchDocumentsQueryFilterReferenceValueBffConverter.ToDto(v),
            SearchDocumentsQueryFilterStringValueBff v => SearchDocumentsQueryFilterStringValueBffConverter.ToDto(v),
            _ => throw new ArgumentTypeOutOfRangeException(value)
        };

        return result;
    }
}
