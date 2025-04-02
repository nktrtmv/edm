using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifiers;

public sealed class DocumentClassifier
{
    public DocumentClassifier(BusinessSegment[] businessSegments, DocumentCategory[] documentCategories)
    {
        BusinessSegments = businessSegments;
        DocumentCategories = documentCategories;
    }

    public BusinessSegment[] BusinessSegments { get; }
    public DocumentCategory[] DocumentCategories { get; }
}
