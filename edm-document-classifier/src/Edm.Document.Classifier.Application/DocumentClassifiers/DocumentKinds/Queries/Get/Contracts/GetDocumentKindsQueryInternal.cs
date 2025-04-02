using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentKinds.Queries.Get.Contracts;

public sealed class GetDocumentKindsQueryInternal : IRequest<GetDocumentKindsQueryInternalResponse>
{
    public GetDocumentKindsQueryInternal(string documentCategoryId, string documentTypeId)
    {
        DocumentCategoryId = documentCategoryId;
        DocumentTypeId = documentTypeId;
    }

    public string DocumentCategoryId { get; }
    public string DocumentTypeId { get; }
}
