using Dapper;

using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Conditions.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Abstractions.Repositories.Rules;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Conditions.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Rules.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<IApprovalConditionsOperatorsRepository, ApprovalConditionsOperatorsRepository>();
        services.AddSingleton<IApprovalRulesRepository, ApprovalRulesRepository>();
    }
}
