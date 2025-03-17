using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Boolean;

public sealed class GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValue
    : GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric<bool>
{
    public GetDocumentsQueryInternalResponseSearchDocumentBooleanAttributeValue(
        int registryRoleId,
        bool[] values) : base(registryRoleId, values)
    {
    }
}
