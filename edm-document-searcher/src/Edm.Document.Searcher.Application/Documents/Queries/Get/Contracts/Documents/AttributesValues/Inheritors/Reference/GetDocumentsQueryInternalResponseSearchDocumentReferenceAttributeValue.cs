using Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Abstractions;

namespace Edm.Document.Searcher.Application.Documents.Queries.Get.Contracts.Documents.AttributesValues.Inheritors.Reference;

public sealed class GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValue
    : GetDocumentsQueryInternalResponseSearchDocumentAttributeValueGeneric<string>
{
    public GetDocumentsQueryInternalResponseSearchDocumentReferenceAttributeValue(
        int registryRoleId,
        string[] values,
        string? referenceType,
        List<GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValue>? parents) : base(registryRoleId, values)
    {
        ReferenceType = referenceType;
        Parents = parents;
    }

    public string? ReferenceType { get; set; }

    public List<GetDocumentsQueryInternalResponseSearchDocumentParentReferenceAttributeValue>? Parents { get; set; }
}
