using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.Domains;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.RegistryRoles;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Document.Searcher.ExternalServices.DocumentClassifier;

public static class DocumentClassifierRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-classifier:5001";

        services.AddGrpcClient<DocumentRegistryRolesService.DocumentRegistryRolesServiceClient>(o => o.Address = new Uri(serviceUri));
        services.AddGrpcClient<ReferencesService.ReferencesServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentsRegistryRolesClient, DocumentsRegistryRolesClient>();
        services.AddSingleton<IDomainsClient, DomainsClient>();
    }
}
