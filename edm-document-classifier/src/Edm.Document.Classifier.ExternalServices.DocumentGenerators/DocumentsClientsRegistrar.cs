using Edm.Document.Classifier.ExternalServices.DocumentGenerators.Details;
using Edm.Document.Classifier.ExternalServices.DocumentGenerators.DocumentsTemplatesDetails;
using Edm.Document.Classifier.ExternalServices.Documents.Details;
using Edm.Document.Classifier.ExternalServices.DocumentsTemplates.Details;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Classifier.ExternalServices.DocumentGenerators;

public static class DocumentsClientsRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-generator:5004";

        services.AddGrpcClient<DocumentsDetailsService.DocumentsDetailsServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddGrpcClient<DocumentsTemplatesDetailsService.DocumentsTemplatesDetailsServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentsDetailsClient, DocumentsDetailsClient>();
        services.AddSingleton<IDocumentsTemplatesDetails, DocumentsTemplatesDetailsClient>();
    }
}
