namespace Edm.Document.Classifier.Application.DocumentClassifications.Contracts;

public sealed class DocumentClassifierSubsetInternal
{
    public DocumentClassifierSubsetInternal(string[] businessSegmentIds, DocumentClassifierSubsetInternalDocumentCategory documentCategory)
    {
        BusinessSegmentIds = businessSegmentIds;
        DocumentCategory = documentCategory;
    }

    public string[] BusinessSegmentIds { get; }
    public DocumentClassifierSubsetInternalDocumentCategory DocumentCategory { get; }
}
