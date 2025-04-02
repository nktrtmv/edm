using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Contracts.Classifications;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Converters;

internal static class SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalConverter
{
    internal static SearchDocumentClassificationQuery ToDto(SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal query)
    {
        DocumentClassifierClassificationExternal classification = query.Classification;

        var businessSegmentId = IdConverterTo.ToString(classification.BusinessSegmentId);

        var documentCategoryId = IdConverterTo.ToString(classification.DocumentCategoryId);

        var documentTypeId = IdConverterTo.ToString(classification.DocumentTypeId);

        var documentKindId = IdConverterTo.ToString(classification.DocumentKindId);

        var result = new SearchDocumentClassificationQuery
        {
            BusinessSegmentId = businessSegmentId,
            DocumentCategoryId = documentCategoryId,
            DocumentTypeId = documentTypeId,
            DocumentKindId = documentKindId
        };

        return result;
    }
}
