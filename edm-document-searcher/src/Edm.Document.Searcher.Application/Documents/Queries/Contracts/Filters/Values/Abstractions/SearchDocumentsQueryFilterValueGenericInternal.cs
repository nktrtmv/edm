namespace Edm.Document.Searcher.Application.Documents.Queries.Contracts.Filters.Values.Abstractions;

public abstract class SearchDocumentsQueryFilterValueGenericInternal<T> : SearchDocumentsQueryFilterValueInternal
{
    protected SearchDocumentsQueryFilterValueGenericInternal(T value)
    {
        Value = value;
    }

    public T Value { get; }
}
