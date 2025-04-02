using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Abstractions;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Date;

public sealed class GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue
    : GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric<
        UtcDateTime<GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue>>
{
    public GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue(
        int registryRoleId,
        UtcDateTime<GetDocumentsQueryInternalResponseSearchDocumentDateAttributeValue>[] values) : base(registryRoleId, values)
    {
    }
}
