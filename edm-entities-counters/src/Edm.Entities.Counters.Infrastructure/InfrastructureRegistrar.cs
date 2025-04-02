using Dapper;

using Edm.Entities.Counters.Infrastructure.Abstractions.Repositories;
using Edm.Entities.Counters.Infrastructure.Repositories.Counters;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Counters.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        services.AddSingleton<ICounterRepository, CounterRepository>();
    }
}
