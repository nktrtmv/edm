using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Services.Updaters.DocumentKinds;

internal static class DocumentKindsDocumentClassificationUpdater
{
    public static void Upsert(DocumentClassification classification, Id<DocumentType> typeId, params Id<DocumentKind>[] kindsIdsToAdd)
    {
        var typesSubsets = classification.DocumentClassifierSubset.DocumentCategory.DocumentTypes
            .Select(t => Upsert(t, typeId, kindsIdsToAdd))
            .ToArray();

        var categorySubset = new DocumentCategorySubset(classification.DocumentClassifierSubset.DocumentCategory.Id, typesSubsets);

        var classifierSubset = new DocumentClassifierSubset(classification.DocumentClassifierSubset.BusinessSegmentIds, categorySubset);

        classification.SetDocumentClassifierSubset(classifierSubset);
    }

    public static void Replace(DocumentClassification classification, Id<DocumentKind> kindFrom, Id<DocumentKind> kindTo)
    {
        foreach (var documentType in classification.DocumentClassifierSubset.DocumentCategory.DocumentTypes)
        {
            Replace(documentType, kindFrom, kindTo);
        }
    }

    private static DocumentTypeSubset Upsert(DocumentTypeSubset type, Id<DocumentType> typeId, params Id<DocumentKind>[] kindsToAdd)
    {
        if (type.DocumentTypeId != typeId)
        {
            return type;
        }

        var kinds = type.DocumentKindIds
            .Concat(kindsToAdd)
            .Distinct()
            .ToArray();

        var result = DocumentTypeSubsetFactory.CreateFrom(typeId, kinds);

        return result;
    }

    private static void Replace(DocumentTypeSubset type, Id<DocumentKind> kindFrom, Id<DocumentKind> kindTo)
    {
        var kindFromIndex = Array.IndexOf(type.DocumentKindIds, kindFrom);

        if (kindFromIndex == -1)
        {
            return;
        }

        type.DocumentKindIds[kindFromIndex] = kindTo;
    }
}
