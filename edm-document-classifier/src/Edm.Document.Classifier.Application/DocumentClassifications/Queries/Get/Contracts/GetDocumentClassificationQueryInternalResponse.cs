using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Get.Contracts;

public sealed class GetDocumentClassificationQueryInternalResponse
{
    public GetDocumentClassificationQueryInternalResponse(DocumentClassificationReadModelInternal documentClassification)
    {
        DocumentClassification = documentClassification;
    }

    public DocumentClassificationReadModelInternal DocumentClassification { get; }
}
