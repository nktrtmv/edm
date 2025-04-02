using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Abstractions;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Number;

public sealed class GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue
    : GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric<Number<GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue>>
{
    public GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue(
        int registryRoleId,
        Number<GetDocumentsQueryInternalResponseSearchDocumentNumberAttributeValue>[] values) : base(registryRoleId, values)
    {
    }
}
