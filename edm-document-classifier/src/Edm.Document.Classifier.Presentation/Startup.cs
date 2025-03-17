using Edm.Document.Classifier.Application;
using Edm.Document.Classifier.Application.DocumentClassifications.Contracts;
using Edm.Document.Classifier.Application.DocumentReferences.Services;
using Edm.Document.Classifier.ExternalServices.Categories;
using Edm.Document.Classifier.ExternalServices.Contractors;
using Edm.Document.Classifier.ExternalServices.DocumentGenerators;
using Edm.Document.Classifier.ExternalServices.DocumentsSearchers;
using Edm.Document.Classifier.ExternalServices.Employees;
using Edm.Document.Classifier.Infrastructure;
using Edm.Document.Classifier.Presentation.Controllers;
using Edm.Document.Classifier.Presentation.Controllers.ApprovalRules.References;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifications;
using Edm.Document.Classifier.Presentation.Controllers.DocumentClassifiers;
using Edm.Document.Classifier.Presentation.Controllers.DocumentReferences;
using Edm.Document.Classifier.Presentation.Controllers.DocumentRegistryRoles;
using Edm.Document.Classifier.Presentation.Controllers.DocumentSystemAttributes;
using Edm.Document.Classifier.Presentation.Controllers.DomainActions;
using Edm.Document.Classifier.Presentation.Controllers.References;

namespace Edm.Document.Classifier.Presentation;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var assembly = typeof(DocumentClassifierSubsetInternal).Assembly;

        services.AddControllers();
        services.AddMemoryCache();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        services.AddLogging();

        InfrastructureServicesRegistrar.Configure(services);
        ApplicationRegistrar.Configure(services);
        DocumentsClientsRegistrar.Configure(services);
        DocumentsSearchersClientsRegistrar.Configure(services);
        CategoryClientRegistrar.Configure(services);
        ContractorsClientRegistrar.Configure(services);
        EmployeesClientRegistrar.Configure(services);
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapGrpcService<ApprovalReferencesController>();
                endpoints.MapGrpcService<DocumentClassificationController>();
                endpoints.MapGrpcService<DocumentClassifierController>();
                endpoints.MapGrpcService<DocumentReferencesController>();
                endpoints.MapGrpcService<ReferencesController>();
                endpoints.MapGrpcService<DocumentRegistryRolesController>();
                endpoints.MapGrpcService<DocumentSystemAttributesController>();
                endpoints.MapGrpcService<DocumentRolesController>();
                endpoints.MapGrpcService<DomainActionsController>();
                endpoints.MapControllers();
            });

        using var scope = app.ApplicationServices.CreateScope();

        var domainsWarmUpService = scope.ServiceProvider.GetRequiredService<DomainsWarmUpService>();
        domainsWarmUpService.WarmUp().GetAwaiter().GetResult();

        var referencesWarmUpService = scope.ServiceProvider.GetRequiredService<ReferencesWarmUpService>();
        referencesWarmUpService.WarmUp().GetAwaiter().GetResult();
    }
}
