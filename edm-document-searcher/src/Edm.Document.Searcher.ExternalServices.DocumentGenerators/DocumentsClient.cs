using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get;
using Edm.Document.Searcher.ExternalServices.DocumentGenerators.Converters.Queries.Get.Documents;
using Edm.Document.Searcher.ExternalServices.Documents;
using Edm.Document.Searcher.ExternalServices.Documents.Contracts;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators;

internal sealed class DocumentsClient : IDocumentsClient
{
    public DocumentsClient(DocumentsService.DocumentsServiceClient client, ILogger<DocumentsClient> logger)
    {
        Client = client;
        Logger = logger;
    }

    private DocumentsService.DocumentsServiceClient Client { get; }
    private ILogger<DocumentsClient> Logger { get; }

    async Task<DocumentExternal> IDocumentsClient.Get(Id<DocumentExternal> id, CancellationToken cancellationToken)
    {
        GetDocumentQuery query = GetDocumentQueryConverter.FromExternal(id);

        GetDocumentQueryResponse response = await TracingFacility.TraceGrpc(
            Logger,
            nameof(IDocumentsClient.Get),
            query,
            async () => await Client.GetAsync(query, cancellationToken: cancellationToken));

        DocumentExternal result = DocumentExternalConverter.FromDto(response.Document);

        return result;
    }
}
