namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Abstractions;

public abstract class GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric<T>
    : GetDocumentsQueryInternalResponseSearchDocumentAttributeValue
{
    protected GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric(int registryRoleId, T[] values) : base(registryRoleId)
    {
        Values = values;
    }

    public T[] Values { get; }
}
