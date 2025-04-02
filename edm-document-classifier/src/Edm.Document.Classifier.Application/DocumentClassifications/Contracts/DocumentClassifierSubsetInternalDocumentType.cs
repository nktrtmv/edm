namespace Edm.Document.Classifier.Application.DocumentClassifications.Contracts;

public sealed class DocumentClassifierSubsetInternalDocumentType
{
    public DocumentClassifierSubsetInternalDocumentType(string documentTypeId, string[] documentKindIds)
    {
        DocumentTypeId = documentTypeId;
        DocumentKindIds = documentKindIds;
    }

    public string DocumentTypeId { get; }
    public string[] DocumentKindIds { get; }
}
