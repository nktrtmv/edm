using System.Reflection;

using Edm.Entities.Approval.Rules.Application;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Infrastructure;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Externals.Rules;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Conditions.Operators;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Groups;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.GroupsDetails;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules;

namespace Edm.Entities.Approval.Rules.Presentation;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(ApprovalRuleInternal).Assembly;

        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(options => { options.EnableDetailedErrors = true; });
        services.AddLogging();

        InfrastructureRegistrar.Configure(services);
        ApplicationServicesRegistrar.Configure(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<ApprovalRulesExternalController>();
                endpoints.MapGrpcService<ApprovalRulesInternalController>();

                endpoints.MapGrpcService<ApprovalConditionsOperatorsController>();
                endpoints.MapGrpcService<ApprovalGraphsController>();
                endpoints.MapGrpcService<ApprovalGroupsController>();
                endpoints.MapGrpcService<ApprovalGroupsDetailsController>();
            });
    }
}
