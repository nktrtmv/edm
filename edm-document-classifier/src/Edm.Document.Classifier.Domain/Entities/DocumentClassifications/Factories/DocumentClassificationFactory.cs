using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Factories;

public static class DocumentClassificationFactory
{
    public static DocumentClassification Create(DocumentClassifier documentClassifier, DocumentClassifierSubset documentClassifierSubset, string name)
    {
        var result = new DocumentClassification(Id<DocumentTemplate>.CreateNew(), documentClassifierSubset, DateTime.UtcNow, DateTime.UtcNow, name);

        return result;
    }

    public static DocumentClassification FromDb(
        Id<DocumentTemplate> documentTemplateId,
        DocumentClassifierSubset documentClassifierSubset,
        string name,
        DateTime createdDate,
        DateTime updatedDate)
    {
        var result = new DocumentClassification(documentTemplateId, documentClassifierSubset, createdDate, updatedDate, name);

        return result;
    }
}
