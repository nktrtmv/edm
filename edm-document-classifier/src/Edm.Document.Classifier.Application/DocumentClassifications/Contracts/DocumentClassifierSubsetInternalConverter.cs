using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Contracts;

internal static class ClassifierPatternInternalConverter
{
    public static DocumentClassifierSubsetInternal FromDomain(DocumentClassifierSubset documentClassifierSubset)
    {
        DocumentClassifierSubsetInternalDocumentType[] types = documentClassifierSubset.DocumentCategory.DocumentTypes.Select(
                t =>
                {
                    string[] kinds = t.DocumentKindIds.Select(k => k.ToString()).ToArray();

                    return new DocumentClassifierSubsetInternalDocumentType(t.DocumentTypeId.ToString(), kinds);
                })
            .ToArray();

        var categoryResult = new DocumentClassifierSubsetInternalDocumentCategory(documentClassifierSubset.DocumentCategory.Id.ToString(), types);

        string[] businessSegmentIds = documentClassifierSubset.BusinessSegmentIds.Select(b => b.ToString()).ToArray();

        var result = new DocumentClassifierSubsetInternal(businessSegmentIds, categoryResult);

        return result;
    }

    public static DocumentClassifierSubset ToDomain(DocumentClassifierSubsetInternal documentClassifierSubsetInternal)
    {
        DocumentTypeSubset[] types = documentClassifierSubsetInternal.DocumentCategory.DocumentTypes.Select(
                t =>
                {
                    Id<DocumentKind>[] kinds = t.DocumentKindIds.Select(IdConverterFrom<DocumentKind>.FromString).ToArray();
                    Id<DocumentType> id = IdConverterFrom<DocumentType>.FromString(t.DocumentTypeId);

                    return new DocumentTypeSubset(id, kinds);
                })
            .ToArray();

        Id<DocumentCategory> id = IdConverterFrom<DocumentCategory>.FromString(documentClassifierSubsetInternal.DocumentCategory.Id);

        var categoryResult = new DocumentCategorySubset(id, types);

        Id<BusinessSegment>[] businessSegmentIds = documentClassifierSubsetInternal.BusinessSegmentIds.Select(IdConverterFrom<BusinessSegment>.FromString).ToArray();

        var result = new DocumentClassifierSubset(businessSegmentIds, categoryResult);

        return result;
    }
}
