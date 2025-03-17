using Dapper;

using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Repositories.SigningWorkflows;
using Edm.Entities.Signing.Workflows.Infrastructure.Repositories.Workflows;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Signing.Workflows.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<ISigningWorkflowsRepository, SigningWorkflowsRepository>();
    }
}
