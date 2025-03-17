namespace Edm.Document.Classifier.Application.DocumentClassifications.Contracts;

public sealed class DocumentClassifierSubsetInternalDocumentCategory
{
    public DocumentClassifierSubsetInternalDocumentCategory(string id, DocumentClassifierSubsetInternalDocumentType[] documentTypes)
    {
        Id = id;
        DocumentTypes = documentTypes;
    }

    public string Id { get; }
    public DocumentClassifierSubsetInternalDocumentType[] DocumentTypes { get; }
}
