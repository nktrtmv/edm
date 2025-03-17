using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Boolean;

public sealed class SearchDocumentsQueryFilterBooleanValueInternal
    : SearchDocumentsQueryFilterValueGenericInternal<bool>
{
    public SearchDocumentsQueryFilterBooleanValueInternal(bool value) : base(value)
    {
    }
}
