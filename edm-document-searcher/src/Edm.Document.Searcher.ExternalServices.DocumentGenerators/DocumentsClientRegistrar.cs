using Edm.Document.Searcher.ExternalServices.Documents;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Searcher.ExternalServices.DocumentGenerators;

public static class DocumentsClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-generator:5004";

        services.AddGrpcClient<DocumentsService.DocumentsServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentsClient, DocumentsClient>();
    }
}
