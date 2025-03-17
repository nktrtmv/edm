using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.Domain.ValueObjects.Classifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Repositories.Contracts;

namespace Edm.DocumentGenerators.Infrastructure.Repositories.Documents.Contracts.Classifications;

internal static class DocumentClassificationDbConverter
{
    internal static DocumentClassificationDb FromDomain(DocumentClassification classification)
    {
        var businessSegmentId = IdConverterTo.ToString(classification.BusinessSegmentId);

        var documentCategoryId = IdConverterTo.ToString(classification.DocumentCategoryId);

        var documentTypeId = IdConverterTo.ToString(classification.DocumentTypeId);

        var documentKindId = IdConverterTo.ToString(classification.DocumentKindId);

        var result = new DocumentClassificationDb
        {
            BusinessSegmentId = businessSegmentId,
            DocumentCategoryId = documentCategoryId,
            DocumentTypeId = documentTypeId,
            DocumentKindId = documentKindId
        };

        return result;
    }

    internal static DocumentClassification ToDomain(DocumentClassificationDb classification)
    {
        Id<BusinessSegment> businessSegmentId = IdConverterFrom<BusinessSegment>.FromString(classification.BusinessSegmentId);

        Id<DocumentCategory> documentCategoryId = IdConverterFrom<DocumentCategory>.FromString(classification.DocumentCategoryId);

        Id<DocumentType> documentTypeId = IdConverterFrom<DocumentType>.FromString(classification.DocumentTypeId);

        Id<DocumentKind> documentKindId = IdConverterFrom<DocumentKind>.FromString(classification.DocumentKindId);

        var result = new DocumentClassification(businessSegmentId, documentCategoryId, documentTypeId, documentKindId);

        return result;
    }
}
