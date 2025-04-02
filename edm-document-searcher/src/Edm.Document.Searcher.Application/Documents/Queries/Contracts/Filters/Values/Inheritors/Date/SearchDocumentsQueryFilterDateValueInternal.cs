using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Abstractions;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Date;

public sealed class SearchDocumentsQueryFilterDateValueInternal
    : SearchDocumentsQueryFilterValueGenericInternal<UtcDateTime<SearchDocumentsQueryFilterInternal>>
{
    public SearchDocumentsQueryFilterDateValueInternal(UtcDateTime<SearchDocumentsQueryFilterInternal> value) : base(value)
    {
    }
}
