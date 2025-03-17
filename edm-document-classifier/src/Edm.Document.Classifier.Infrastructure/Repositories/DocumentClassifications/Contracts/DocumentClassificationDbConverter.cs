using Edm.Document.Classifier.Domain.Entities.DocumentClassifications;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Factories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.Markers;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications.Contracts.Protos.Subsets;

using Google.Protobuf;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications.Contracts;

internal static class DocumentClassificationDbConverter
{
    internal static DocumentClassificationDb FromDomain(DocumentClassification documentClassification)
    {
        var data = FromDomainToData(documentClassification);

        var result = new DocumentClassificationDb
        {
            DocumentTemplateId = documentClassification.DocumentTemplateId.ToString(),
            CreatedDate = documentClassification.CreatedDate,
            UpdatedDate = documentClassification.UpdatedDate,
            Data = data.ToByteArray(),
            DataForSearch = "{}"
        };

        return result;
    }

    internal static DocumentClassification ToDomain(DocumentClassificationDb db)
    {
        var data = DocumentClassificationDataDb.Parser.ParseFrom(db.Data);

        var subset = ToDomain(data.DocumentClassifierSubset);

        Id<DocumentTemplate> id = IdConverterFrom<DocumentTemplate>.FromString(db.DocumentTemplateId);

        var result = DocumentClassificationFactory.FromDb(id, subset, data.Name, db.CreatedDate, db.UpdatedDate);

        return result;
    }

    private static DocumentClassificationDataDb FromDomainToData(DocumentClassification documentClassification)
    {
        DocumentTypeSubsetDb[] types = documentClassification.DocumentClassifierSubset.DocumentCategory.DocumentTypes.Select(
                t =>
                {
                    string[] kinds = t.DocumentKindIds.Select(k => k.ToString()).ToArray();

                    return new DocumentTypeSubsetDb
                    {
                        DocumentTypeId = t.DocumentTypeId.ToString(),
                        DocumentKindIds = { kinds }
                    };
                })
            .ToArray();

        var categoryResult = new DocumentCategorySubsetDb
        {
            DocumentCategoryId = documentClassification.DocumentClassifierSubset.DocumentCategory.Id.ToString(),
            DocumentTypes = { types }
        };

        var subset = new DocumentClassifierSubsetDb
        {
            BusinessSegmentIds =
            {
                documentClassification.DocumentClassifierSubset.BusinessSegmentIds.Select(b => b.ToString())
            },
            DocumentCategory = categoryResult
        };

        var result = new DocumentClassificationDataDb
        {
            Name = documentClassification.Name,
            DocumentClassifierSubset = subset
        };

        return result;
    }

    private static DocumentClassifierSubset ToDomain(DocumentClassifierSubsetDb documentClassifierSubsetDb)
    {
        var types = documentClassifierSubsetDb.DocumentCategory.DocumentTypes
            .Select(DocumentTypeSubsetDbToDomainConverter.ToDomain)
            .ToArray();

        Id<DocumentCategory> id = IdConverterFrom<DocumentCategory>.FromString(documentClassifierSubsetDb.DocumentCategory.DocumentCategoryId);

        var categoryResult = new DocumentCategorySubset(id, types);

        Id<BusinessSegment>[] businessSegmentIds = documentClassifierSubsetDb
            .BusinessSegmentIds
            .Select(IdConverterFrom<BusinessSegment>.FromString)
            .ToArray();

        var result = new DocumentClassifierSubset(businessSegmentIds, categoryResult);

        return result;
    }
}
