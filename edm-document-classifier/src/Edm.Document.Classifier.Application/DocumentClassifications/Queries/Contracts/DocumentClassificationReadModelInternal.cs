using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Contracts;

public sealed class DocumentClassificationReadModelInternal
{
    public DocumentClassificationReadModelInternal(string documentClassificationId, string name, DocumentClassifierSubsetInternal documentClassifierSubset)
    {
        DocumentTemplateId = documentClassificationId;
        Name = name;
        DocumentClassifierSubset = documentClassifierSubset;
    }

    public string DocumentTemplateId { get; }
    public string Name { get; }
    public DocumentClassifierSubsetInternal DocumentClassifierSubset { get; }
}
