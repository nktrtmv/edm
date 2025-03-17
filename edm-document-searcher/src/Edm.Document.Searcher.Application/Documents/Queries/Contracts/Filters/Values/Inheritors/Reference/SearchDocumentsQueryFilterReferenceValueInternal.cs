using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.Reference;

public sealed class SearchDocumentsQueryFilterReferenceValueInternal
    : SearchDocumentsQueryFilterValueGenericInternal<string>
{
    public SearchDocumentsQueryFilterReferenceValueInternal(string value) : base(value)
    {
    }
}
