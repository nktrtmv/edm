using Edm.Document.Searcher.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.ExternalServices.DocumentsSearchers;

public static class DocumentsSearchersClientsRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-searcher:5003";

        services.AddGrpcClient<SearchDocumentsService.SearchDocumentsServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentsSearchersClient, DocumentsSearchersClient>();
    }
}
