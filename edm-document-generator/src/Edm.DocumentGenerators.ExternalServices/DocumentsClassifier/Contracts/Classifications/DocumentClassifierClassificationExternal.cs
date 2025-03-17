using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Contracts.Classifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Contracts.Classifications;

public sealed class DocumentClassifierClassificationExternal
{
    public DocumentClassifierClassificationExternal(
        Id<BusinessSegmentExternal> businessSegmentId,
        Id<DocumentCategoryExternal> documentCategoryId,
        Id<DocumentTypeExternal> documentTypeId,
        Id<DocumentKindExternal> documentKindId)
    {
        BusinessSegmentId = businessSegmentId;
        DocumentCategoryId = documentCategoryId;
        DocumentTypeId = documentTypeId;
        DocumentKindId = documentKindId;
    }

    public Id<BusinessSegmentExternal> BusinessSegmentId { get; }
    public Id<DocumentCategoryExternal> DocumentCategoryId { get; }
    public Id<DocumentTypeExternal> DocumentTypeId { get; }
    public Id<DocumentKindExternal> DocumentKindId { get; }
}
