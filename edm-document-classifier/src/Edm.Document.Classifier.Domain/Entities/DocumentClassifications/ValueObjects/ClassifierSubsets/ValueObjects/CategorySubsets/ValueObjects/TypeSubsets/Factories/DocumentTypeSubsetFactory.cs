using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets.Factories;

internal static class DocumentTypeSubsetFactory
{
    internal static DocumentTypeSubset CreateFrom(string type, params string[] kinds)
    {
        Id<DocumentType> typeId = IdConverterFrom<DocumentType>.FromString(type);

        Id<DocumentKind>[] kindsIds = kinds.Select(IdConverterFrom<DocumentKind>.FromString).ToArray();

        DocumentTypeSubset result = CreateFrom(typeId, kindsIds);

        return result;
    }

    internal static DocumentTypeSubset CreateFrom(Id<DocumentType> typeId, params Id<DocumentKind>[] kindsIds)
    {
        var result = new DocumentTypeSubset(typeId, kindsIds);

        return result;
    }
}
