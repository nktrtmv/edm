using Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Inheritors.String;

public sealed class SearchDocumentsQueryFilterStringValueInternal
    : SearchDocumentsQueryFilterValueGenericInternal<string>
{
    public SearchDocumentsQueryFilterStringValueInternal(string value) : base(value)
    {
    }
}
