using Edm.DocumentGenerators.Domain.ValueObjects.Classifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.ValueObjects.Classifications;

public sealed record DocumentClassification(
    Id<BusinessSegment> BusinessSegmentId,
    Id<DocumentCategory> DocumentCategoryId,
    Id<DocumentType> DocumentTypeId,
    Id<DocumentKind> DocumentKindId)
{
    public override string ToString()
    {
        return
            $"{{ BusinessSegmentId: {BusinessSegmentId}, DocumentCategoryId: {DocumentCategoryId}, DocumentTypeId: {DocumentTypeId}, DocumentKindId: {DocumentKindId} }}";
    }
}
