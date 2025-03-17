using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentClassifications;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.DocumentRoles;
using Edm.DocumentGenerators.ExternalServices.DocumentsClassifier.Clients.Domains;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsClassifier;

public static class DocumentClassifierRegistrar
{
    private const string ServiceName = "edm-document-classifier";

    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-classifier:5001";

        services.AddGrpcClient<DocumentClassificationService.DocumentClassificationServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddGrpcClient<DocumentRegistryRolesService.DocumentRegistryRolesServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddGrpcClient<DocumentRolesService.DocumentRolesServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentClassificationsDocumentsClassifierClient, DocumentClassificationsDocumentsClassifierClient>();
        services.AddSingleton<IDocumentRolesClient, DocumentRolesClient>();
        services.AddSingleton<IDomainsClient, DomainsClient>();
    }
}
