using Edm.DocumentGenerators.Domain.ValueObjects.Classifications;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Contracts.Classifications;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Contracts.Classifications.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.ByClassification.Services.Searchers.Converters;

internal static class SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalConverter
{
    internal static SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal FromDomain(DocumentClassification classification)
    {
        Id<BusinessSegmentExternal> businessSegmentId =
            IdConverterFrom<BusinessSegmentExternal>.From(classification.BusinessSegmentId);

        Id<DocumentCategoryExternal> documentCategoryId =
            IdConverterFrom<DocumentCategoryExternal>.From(classification.DocumentCategoryId);

        Id<DocumentTypeExternal> documentTypeId =
            IdConverterFrom<DocumentTypeExternal>.From(classification.DocumentTypeId);

        Id<DocumentKindExternal> documentKindId =
            IdConverterFrom<DocumentKindExternal>.From(classification.DocumentKindId);

        var classificationExternal = new DocumentClassifierClassificationExternal(businessSegmentId, documentCategoryId, documentTypeId, documentKindId);

        var result = new SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal(classificationExternal);

        return result;
    }
}
