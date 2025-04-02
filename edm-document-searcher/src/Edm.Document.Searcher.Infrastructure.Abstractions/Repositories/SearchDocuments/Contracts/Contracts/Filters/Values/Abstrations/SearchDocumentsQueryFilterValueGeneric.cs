namespace Edm.Document.Searcher.Infrastructure.Abstractions.Repositories.SearchDocuments.Contracts.Contracts.Filters.Values.Abstrations;

public abstract class SearchDocumentsQueryFilterValueGeneric<T> : SearchDocumentsQueryFilterValue
{
    protected SearchDocumentsQueryFilterValueGeneric(T value)
    {
        Value = value;
    }

    public T Value { get; }
}
