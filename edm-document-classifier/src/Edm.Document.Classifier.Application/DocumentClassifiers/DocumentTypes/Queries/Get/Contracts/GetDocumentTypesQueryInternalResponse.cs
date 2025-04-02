namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;

public sealed class GetDocumentTypesQueryInternalResponse
{
    public GetDocumentTypesQueryInternalResponse(GetDocumentTypesQueryInternalResponseDocumentType[] documentTypes)
    {
        DocumentTypes = documentTypes;
    }

    public GetDocumentTypesQueryInternalResponseDocumentType[] DocumentTypes { get; }
}
