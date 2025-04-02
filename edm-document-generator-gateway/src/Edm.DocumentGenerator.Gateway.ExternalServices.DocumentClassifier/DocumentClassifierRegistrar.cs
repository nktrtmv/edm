using Edm.Document.Classifier.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.DomainActions;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.RegistryRoles;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier.Roles;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier;

public static class DocumentClassifierRegistrar
{
    public const string ServiceUri = "http://edm-document-classifier:5001";

    public static void Configure(IServiceCollection services)
    {
        services.AddGrpcClient<DocumentRegistryRolesService.DocumentRegistryRolesServiceClient>(o => o.Address = new Uri(ServiceUri));
        services.AddGrpcClient<DocumentRolesService.DocumentRolesServiceClient>(o => o.Address = new Uri(ServiceUri));
        services.AddGrpcClient<DomainActionsService.DomainActionsServiceClient>(o => o.Address = new Uri(ServiceUri));

        services.AddSingleton<IDocumentsRegistryRolesClient, DocumentsRegistryRolesClient>();
        services.AddSingleton<IDocumentsRolesClient, DocumentRolesClient>();
        services.AddSingleton<IDomainActionsClient, DomainActionsClient>();
    }
}
