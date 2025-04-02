using System.Reflection;

using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Infrastructure;
using Edm.Entities.Counters.Presentation.Controllers.Counters;

namespace Edm.Entities.Counters.Presentation;

public sealed class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(CounterInternal).Assembly;

        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        services.AddLogging();

        InfrastructureRegistrar.Configure(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<EntitiesCountersController>();
                endpoints.MapGrpcService<EntitiesCountersIncrementerController>();
            });
    }
}
