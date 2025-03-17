using MediatR;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;

public sealed class GetDocumentClassificationQueryInternal : IRequest<GetDocumentClassificationQueryInternalResponse>
{
    public GetDocumentClassificationQueryInternal(string documentClassificationId)
    {
        DocumentTemplateId = documentClassificationId;
    }

    public string DocumentTemplateId { get; }
}
