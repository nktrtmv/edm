using Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;

public sealed class SearchDocumentClassificationQueryInternalResponse
{
    public SearchDocumentClassificationQueryInternalResponse(DocumentClassificationReadModelInternal[] documentClassifications)
    {
        DocumentClassifications = documentClassifications;
    }

    public DocumentClassificationReadModelInternal[] DocumentClassifications { get; }
}
