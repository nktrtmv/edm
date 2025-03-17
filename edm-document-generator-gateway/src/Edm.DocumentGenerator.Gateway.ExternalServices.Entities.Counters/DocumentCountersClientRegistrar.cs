using Edm.Entities.Counters.Presentation.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters;

public static class DocumentCountersClientRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        const string serviceUri = "http://edm-entities-counters:5005";

        services.AddGrpcClient<EntitiesCountersService.EntitiesCountersServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<IDocumentCountersClient, DocumentCountersClient>();
    }
}
