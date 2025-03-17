namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;

public sealed class GetDocumentKindsQueryInternalResponse
{
    public GetDocumentKindsQueryInternalResponse(GetDocumentKindsQueryInternalResponseDocumentKind[] documentKinds)
    {
        DocumentKinds = documentKinds;
    }

    public GetDocumentKindsQueryInternalResponseDocumentKind[] DocumentKinds { get; }
}
