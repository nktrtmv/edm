using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Services.Updaters.BusinessSegments;

internal static class BusinessSegmentsDocumentClassificationUpdater
{
    internal static void Upsert(DocumentClassification classification, params Id<BusinessSegment>[] businessSegments)
    {
        DocumentClassifierSubset subset = classification.DocumentClassifierSubset;

        Id<BusinessSegment>[] updatedBusinessSegments = subset.BusinessSegmentIds
            .Concat(businessSegments)
            .Distinct()
            .ToArray();

        var updatedSubset = new DocumentClassifierSubset(updatedBusinessSegments, subset.DocumentCategory);

        classification.SetDocumentClassifierSubset(updatedSubset);
    }
}
