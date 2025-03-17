using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifiers.DocumentTypes.Queries.Get.Contracts;

public sealed class GetDocumentTypesQueryInternal : IRequest<GetDocumentTypesQueryInternalResponse>
{
    public GetDocumentTypesQueryInternal(string documentCategoryId)
    {
        DocumentCategoryId = documentCategoryId;
    }

    public string DocumentCategoryId { get; }
}
