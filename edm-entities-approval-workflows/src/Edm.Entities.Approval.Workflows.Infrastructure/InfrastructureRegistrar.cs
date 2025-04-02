using Dapper;

using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Repositories.Workflows;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Workflows.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<IApprovalWorkflowsRepository, ApprovalWorkflowsRepository>();
    }
}
