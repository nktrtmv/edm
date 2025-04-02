using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;
using Edm.DocumentGenerators.ExternalServices.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Converters;

internal static class SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponseConverter
{
    internal static SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse FromDto(SearchDocumentClassificationQueryResponse response)
    {
        Id<DocumentTemplateExternal>[] templatesIds = response.DocumentClassifications
            .Select(n => n.DocumentTemplateId)
            .Select(IdConverterFrom<DocumentTemplateExternal>.FromString)
            .ToArray();

        var result = new SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse(templatesIds);

        return result;
    }
}
