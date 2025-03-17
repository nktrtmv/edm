using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;

namespace Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications.Contracts;

public sealed class DocumentClassificationSearchParams
{
    public DocumentClassificationSearchParams(
        Id<BusinessSegment> businessSegmentId,
        Id<DocumentCategory> documentCategoryId,
        Id<DocumentType> documentTypeId,
        Id<DocumentKind> documentKindId)
    {
        BusinessSegmentId = businessSegmentId;
        DocumentCategoryId = documentCategoryId;
        DocumentTypeId = documentTypeId;
        DocumentKindId = documentKindId;
    }

    public Id<BusinessSegment> BusinessSegmentId { get; }
    public Id<DocumentCategory> DocumentCategoryId { get; }
    public Id<DocumentType> DocumentTypeId { get; }
    public Id<DocumentKind> DocumentKindId { get; }
}
