using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Abstractions;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Number;

public sealed class SearchDocumentsQueryFilterNumberValueInternal
    : SearchDocumentsQueryFilterValueGenericInternal<Number<SearchDocumentsQueryFilterInternal>>
{
    public SearchDocumentsQueryFilterNumberValueInternal(Number<SearchDocumentsQueryFilterInternal> value) : base(value)
    {
    }
}
