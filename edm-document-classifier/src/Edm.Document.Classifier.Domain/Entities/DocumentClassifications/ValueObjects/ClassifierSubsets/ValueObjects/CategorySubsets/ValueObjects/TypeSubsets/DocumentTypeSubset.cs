using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Domain.Entities.DocumentClassifications.ValueObjects.ClassifierSubsets.ValueObjects.CategorySubsets.ValueObjects.TypeSubsets;

public readonly struct DocumentTypeSubset
{
    public DocumentTypeSubset(Id<DocumentType> documentTypeId, Id<DocumentKind>[] documentKindIds)
    {
        DocumentTypeId = documentTypeId;
        DocumentKindIds = documentKindIds;
    }

    public Id<DocumentType> DocumentTypeId { get; }
    public Id<DocumentKind>[] DocumentKindIds { get; }
}
