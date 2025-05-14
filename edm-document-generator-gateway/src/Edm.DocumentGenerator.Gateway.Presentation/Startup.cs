using System.Text.Json.Serialization;

using Edm.Document.Classifier.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.DocumentGenerator.Gateway.Core;
using Edm.DocumentGenerator.Gateway.Core.Documents;
using Edm.DocumentGenerator.Gateway.Core.Extensions;
using Edm.DocumentGenerator.Gateway.ExternalServices.DocumentClassifier;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows;
using Edm.DocumentGenerator.Gateway.Presentation.Authorization;
using Edm.DocumentGenerator.Gateway.Presentation.Configuration;
using Edm.DocumentGenerator.Gateway.Presentation.Users;
using Edm.DocumentGenerators.Presentation.Abstractions;

using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Edm.DocumentGenerator.Gateway.Presentation;

public sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddProblemDetails(o =>
        {
            o.Map<Exception>(e => new ProblemDetails
            {
                Type = e.GetType().Name,
                Title = e.Message,
                Status = StatusCodes.Status500InternalServerError
            });
        });

        services
            .AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

        services.AddKeycloak();
        services.AddSwagger();

        services.AddMemoryCache();

        services.AddGrpc(options => { options.EnableDetailedErrors = true; });

        services.AddSingleton<IRoleAdapter, RoleAdapter>();

        services.AddProblemDetails(ProblemDetailsConfiguration.Configure);
        services.AddSingleton<UsersService>();
        services.AddHttpContextAccessor();

        CoreRegistrar.Configure(Configuration, services);

        const string generatorUri = "http://edm-document-generator:5004";
        services.AddGrpcClient<DocumentTemplateService.DocumentTemplateServiceClient>(o => o.Address = new Uri(generatorUri));
        services.AddGrpcClient<DocumentsService.DocumentsServiceClient>(o => o.Address = new Uri(generatorUri));
        services.AddGrpcClient<DocumentsStatusesParametersService.DocumentsStatusesParametersServiceClient>(o => o.Address = new Uri(generatorUri));
        services.AddGrpcClient<DocumentsTechService.DocumentsTechServiceClient>(o => o.Address = new Uri(generatorUri));

        const string searcherUri = "http://edm-document-searcher:5003";
        services.AddGrpcClient<SearchDocumentsService.SearchDocumentsServiceClient>(o => o.Address = new Uri(searcherUri));

        services.AddGrpcClient<ReferencesService.ReferencesServiceClient>(o => o.Address = new Uri(DocumentClassifierRegistrar.ServiceUri));
        services.AddGrpcClient<DocumentSystemAttributesService.DocumentSystemAttributesServiceClient>(o => o.Address = new Uri(DocumentClassifierRegistrar.ServiceUri));
        services.AddGrpcClient<DocumentClassifierService.DocumentClassifierServiceClient>(o => o.Address = new Uri(DocumentClassifierRegistrar.ServiceUri));
        services.AddGrpcClient<DocumentClassificationService.DocumentClassificationServiceClient>(o => o.Address = new Uri(DocumentClassifierRegistrar.ServiceUri));

        DocumentClassifierRegistrar.Configure(services);
        ApprovalWorkflowsRegistrar.Configure(services);
        SigningClientsRegistrar.Configure(services);
        DocumentCountersClientRegistrar.Configure(services);

        services.AddCoreServices();
        services.AddCors();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseProblemDetails();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors(x => x.AllowAnyOrigin()
            .WithExposedHeaders(HeaderNames.ContentDisposition));

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
