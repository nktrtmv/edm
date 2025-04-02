using Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Infrastructure.Repositories.DocumentClassifications.Contracts.Protos.Subsets;

internal static class DocumentTypeSubsetDbToDomainConverter
{
    internal static DocumentTypeSubset ToDomain(DocumentTypeSubsetDb subset)
    {
        Id<DocumentType> id = IdConverterFrom<DocumentType>.FromString(subset.DocumentTypeId);

        Id<DocumentKind>[] kinds = subset.DocumentKindIds
            .Select(k => MapDocumentKind(subset.DocumentTypeId, k))
            .Select(IdConverterFrom<DocumentKind>.FromString)
            .ToArray();

        var result = new DocumentTypeSubset(id, kinds);

        return result;
    }

    private static string MapDocumentKind(string type, string kind)
    {
        string result = type switch
        {
            "1" => kind switch
            {
                "17" => "1_1_17",
                "26" => "1_1_26",
                "27" => "1_1_27",
                _ => kind
            },
            "7" => kind switch
            {
                "47" => "1_7_47",
                _ => kind
            },
            "8" => kind switch
            {
                "20" => "1_8_20",
                _ => kind
            },
            _ => kind
        };

        return result;
    }
}
