using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications;

public sealed class DocumentClassification
{
    public DocumentClassification(
        Id<DocumentTemplate> documentTemplateId,
        DocumentClassifierSubset documentClassifierSubset,
        DateTime createdDate,
        DateTime updatedDate,
        string name)
    {
        DocumentTemplateId = documentTemplateId;
        DocumentClassifierSubset = documentClassifierSubset;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        Name = name;
    }

    public Id<DocumentTemplate> DocumentTemplateId { get; }
    public DocumentClassifierSubset DocumentClassifierSubset { get; private set; }
    public DateTime CreatedDate { get; }
    public DateTime UpdatedDate { get; }
    public string Name { get; }

    internal void SetDocumentClassifierSubset(DocumentClassifierSubset documentClassifierSubset)
    {
        DocumentClassifierSubset = documentClassifierSubset;
    }
}
