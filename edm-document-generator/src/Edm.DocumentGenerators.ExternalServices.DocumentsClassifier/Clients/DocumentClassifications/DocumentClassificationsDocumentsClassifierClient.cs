using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Contracts;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications.Converters;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications;

internal sealed class DocumentClassificationsDocumentsClassifierClient : IDocumentClassificationsDocumentsClassifierClient
{
    public DocumentClassificationsDocumentsClassifierClient(
        DocumentClassificationService.DocumentClassificationServiceClient client,
        ILogger<DocumentClassificationsDocumentsClassifierClient> logger)
    {
        Client = client;
        Logger = logger;
    }

    private DocumentClassificationService.DocumentClassificationServiceClient Client { get; }
    private ILogger<DocumentClassificationsDocumentsClassifierClient> Logger { get; }

    async Task<SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse>
        IDocumentClassificationsDocumentsClassifierClient.Search(
            SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternal query,
            CancellationToken cancellationToken)
    {
        SearchDocumentClassificationQuery request =
            SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalConverter.ToDto(query);

        SearchDocumentClassificationQueryResponse response = await TracingFacility.TraceGrpc(
            Logger,
            nameof(Client.Search),
            request,
            async () => await Client.SearchAsync(request, cancellationToken: cancellationToken));

        SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponse result =
            SearchDocumentTemplatesIdsDocumentClassificationsDocumentsClassifierQueryExternalResponseConverter.FromDto(response);

        return result;
    }
}
