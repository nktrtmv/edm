using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Contracts.Classifications;

internal static class DocumentClassificationInternalConverter
{
    internal static DocumentClassification ToDomain(DocumentClassificationInternal classification)
    {
        Id<BusinessSegment> businessSegmentId = IdConverterFrom<BusinessSegment>.FromString(classification.BusinessSegmentId);

        Id<DocumentCategory> documentCategoryId = IdConverterFrom<DocumentCategory>.FromString(classification.DocumentCategoryId);

        Id<DocumentType> documentTypeId = IdConverterFrom<DocumentType>.FromString(classification.DocumentTypeId);

        Id<DocumentKind> documentKindId = IdConverterFrom<DocumentKind>.FromString(classification.DocumentKindId);

        var result = new DocumentClassification(businessSegmentId, documentCategoryId, documentTypeId, documentKindId);

        return result;
    }
}
