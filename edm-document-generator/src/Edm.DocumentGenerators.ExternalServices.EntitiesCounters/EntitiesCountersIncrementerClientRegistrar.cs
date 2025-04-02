using Edm.Entities.Counters.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters;

public static class EntitiesCountersIncrementerClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-entities-counters:5005";

        services.AddGrpcClient<EntitiesCountersIncrementerService.EntitiesCountersIncrementerServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IEntitiesCountersIncrementerClient, EntitiesCountersIncrementerClient>();
    }
}
