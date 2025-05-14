using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.DocumentClassifier;
using Edm.Entities.Approval.Rules.Gateway.Presentation.Configuration;

using Hellang.Middleware.ProblemDetails;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Edm.Entities.Approval.Rules.Gateway.Presentation;

public sealed class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

        services.AddProblemDetails(o =>
        {
            o.Map<Exception>(e => new ProblemDetails
            {
                Type = e.GetType().Name,
                Title = e.Message,
                Status = StatusCodes.Status500InternalServerError
            });
        });

        services.AddKeycloak();
        services.AddSwagger();

        services.AddMemoryCache();

        services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        services.AddLogging();

        services.AddHttpContextAccessor();

        CoreRegistrar.Configure(services);
        ApprovalRulesRegistrar.Configure(services);
        DocumentClassifierRegistrar.Configure(services);

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
