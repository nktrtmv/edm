using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;

public readonly struct DocumentClassifierSubset
{
    public DocumentClassifierSubset(Id<BusinessSegment>[] businessSegmentIds, DocumentCategorySubset documentCategory)
    {
        BusinessSegmentIds = businessSegmentIds;
        DocumentCategory = documentCategory;
    }

    public Id<BusinessSegment>[] BusinessSegmentIds { get; }
    public DocumentCategorySubset DocumentCategory { get; }
}
