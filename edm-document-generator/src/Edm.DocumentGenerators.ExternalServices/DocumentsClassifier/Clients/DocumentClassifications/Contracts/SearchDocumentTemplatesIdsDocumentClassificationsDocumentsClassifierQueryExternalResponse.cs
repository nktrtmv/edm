using Edm.DocumentGenerators.ExternalServices.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;

public sealed class SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse
{
    public SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse(Id<DocumentTemplateExternal>[] templatesIds)
    {
        TemplatesIds = templatesIds;
    }

    public Id<DocumentTemplateExternal>[] TemplatesIds { get; }
}
