using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets;

public readonly struct DocumentCategorySubset
{
    public DocumentCategorySubset(Id<DocumentCategory> id, DocumentTypeSubset[] documentTypes)
    {
        Id = id;
        DocumentTypes = documentTypes;
    }

    public Id<DocumentCategory> Id { get; }
    public DocumentTypeSubset[] DocumentTypes { get; }
}
