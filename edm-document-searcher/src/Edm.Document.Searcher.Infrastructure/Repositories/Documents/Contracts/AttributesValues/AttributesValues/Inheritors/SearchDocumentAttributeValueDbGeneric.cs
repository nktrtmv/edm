namespace Edm.Document.Searcher.Infrastructure.Repositories.Documents.Contracts.AttributesValues.AttributesValues.Inheritors;

internal abstract class SearchDocumentAttributeValueDbGeneric<T> : SearchDocumentAttributeValueDb
{
    public required T[] Values { get; init; }
}
