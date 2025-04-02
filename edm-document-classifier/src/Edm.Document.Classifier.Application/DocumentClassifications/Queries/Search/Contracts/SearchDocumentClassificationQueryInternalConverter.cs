using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.BusinessSegments;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes;
using Edm.Document.Classifier.Domain.Entities.DocumentClassifiers.DocumentCategories.DocumentTypes.DocumentKinds;
using Edm.Document.Classifier.GenericSubdomain;
using Edm.Document.Classifier.Infrastructure.Abstractions.Repositories.DocumentClassifications.Contracts;

namespace Edm.Document.Classifier.Application.DocumentClassifications.Queries.Search.Contracts;

internal static class SearchDocumentClassificationQueryInternalConverter
{
    public static DocumentClassificationSearchParams ToSearchParams(SearchDocumentClassificationQueryInternal queryInternal)
    {
        Id<BusinessSegment> businessSegmentId = IdConverterFrom<BusinessSegment>.FromString(queryInternal.BusinessSegmentId);

        Id<DocumentCategory> documentCategoryId = IdConverterFrom<DocumentCategory>.FromString(queryInternal.CategoryId);

        Id<DocumentType> documentTypeId = IdConverterFrom<DocumentType>.FromString(queryInternal.TypeId);

        Id<DocumentKind> documentKindId = IdConverterFrom<DocumentKind>.FromString(queryInternal.KindId);

        var result = new DocumentClassificationSearchParams(businessSegmentId, documentCategoryId, documentTypeId, documentKindId);

        return result;
    }
}
