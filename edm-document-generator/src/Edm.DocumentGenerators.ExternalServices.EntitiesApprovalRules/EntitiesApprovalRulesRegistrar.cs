using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules.Clients;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Externals;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalRules;

public static class EntitiesApprovalRulesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-entities-approval-rules:5006";

        services.AddGrpcClient<ApprovalRulesService.ApprovalRulesServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IEntitiesApprovalRulesClient, EntitiesApprovalRulesClient>();
    }
}
