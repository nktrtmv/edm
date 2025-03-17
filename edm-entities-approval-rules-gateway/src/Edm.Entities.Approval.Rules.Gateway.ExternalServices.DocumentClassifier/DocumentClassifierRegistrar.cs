using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier.Clients.Domains;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier;

public static class DocumentClassifierRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-document-classifier:5001";

        services.AddGrpcClient<DocumentRegistryRolesService.DocumentRegistryRolesServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentClassifierDomainsClient, DocumentClassifierDomainsClient>();
    }
}
