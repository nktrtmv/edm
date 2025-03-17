using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Services.Updaters.DocumentTypes;

internal static class DocumentTypesDocumentClassificationUpdater
{
    internal static void Upsert(DocumentClassification classification, params DocumentTypeSubset[] typesSubsetsToAdd)
    {
        DocumentTypeSubset[] typesSubsets = classification.DocumentClassifierSubset.DocumentCategory.DocumentTypes;

        foreach (DocumentTypeSubset typeSubsetToAdd in typesSubsetsToAdd)
        {
            bool typeSubsetToAddInTypesSubsets = typesSubsets.Any(t => t.DocumentTypeId == typeSubsetToAdd.DocumentTypeId);

            DocumentTypeSubset? typeSubsetFromClassification = typeSubsetToAddInTypesSubsets
                ? typesSubsets.Single(t => t.DocumentTypeId == typeSubsetToAdd.DocumentTypeId)
                : null;

            if (typeSubsetFromClassification is null)
            {
                typesSubsets = typesSubsets.Append(typeSubsetToAdd).ToArray();

                continue;
            }

            Id<DocumentKind>[] mergedKinds = typeSubsetToAdd.DocumentKindIds
                .Concat(typeSubsetFromClassification.Value.DocumentKindIds)
                .Distinct()
                .ToArray();

            var mergedTypeSubset = new DocumentTypeSubset(typeSubsetToAdd.DocumentTypeId, mergedKinds);

            typesSubsets = typesSubsets.Where(t => t.DocumentTypeId != mergedTypeSubset.DocumentTypeId).Append(mergedTypeSubset).ToArray();
        }

        var categorySubset = new DocumentCategorySubset(classification.DocumentClassifierSubset.DocumentCategory.Id, typesSubsets);

        var classifierSubset = new DocumentClassifierSubset(classification.DocumentClassifierSubset.BusinessSegmentIds, categorySubset);

        classification.SetDocumentClassifierSubset(classifierSubset);
    }

    internal static void Delete(DocumentClassification classification, params Id<DocumentType>[] typesToDeleteIds)
    {
        DocumentTypeSubset[] typeSubsets = classification.DocumentClassifierSubset.DocumentCategory.DocumentTypes
            .Where(t => !typesToDeleteIds.Contains(t.DocumentTypeId))
            .ToArray();

        var categorySubset = new DocumentCategorySubset(classification.DocumentClassifierSubset.DocumentCategory.Id, typeSubsets);

        var classifierSubset = new DocumentClassifierSubset(classification.DocumentClassifierSubset.BusinessSegmentIds, categorySubset);

        classification.SetDocumentClassifierSubset(classifierSubset);
    }
}
