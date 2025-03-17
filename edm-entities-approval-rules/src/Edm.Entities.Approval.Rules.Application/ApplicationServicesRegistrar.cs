using Edm.Entities.Approval.Rules.Application.External.Rules.Queries.FindRoute.Services.Finders.Rules;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Services;
using Edm.Entities.Approval.Rules.Application.Internal.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Rules.Application;

public static class ApplicationServicesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ActiveEntityApprovalRuleFinder>();

        services.AddSingleton<ApprovalRulesUpdaterService>();

        services.AddSingleton<ApprovalRulesFacade>();
    }
}
