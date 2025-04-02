namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues;

public abstract class GetDocumentsQueryInternalResponseSearchDocumentAttributeValue
{
    protected GetDocumentsQueryInternalResponseSearchDocumentAttributeValue(int registryRoleId)
    {
        RegistryRoleId = registryRoleId;
    }

    public int RegistryRoleId { get; }
}
