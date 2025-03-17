using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.String;

public sealed class GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValue
    : GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric<string>
{
    public GetDocumentsQueryInternalResponseSearchDocumentStringAttributeValue(
        int registryRoleId,
        string[] values) : base(registryRoleId, values)
    {
    }
}
