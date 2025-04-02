using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications;

public interface IDocumentClassificationsDocumentsClassifierClient
{
    Task<SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse> Search(
        SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal query,
        CancellationToken cancellationToken);
}
