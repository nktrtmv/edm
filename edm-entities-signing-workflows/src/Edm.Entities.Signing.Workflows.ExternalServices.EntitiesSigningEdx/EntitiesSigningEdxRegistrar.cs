using Edm.Entities.Signing.Workflows.GenericSubdomain.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx;

public static class EntitiesSigningEdxRegistrar
{
    public static IClusterConfigurationBuilder ConfigureEntitiesSigningEdx(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        services.AddSingleton<IEntitiesSigningEdxClient, EntitiesSigningEdxClient>();

        cluster
            .AddProducer<EntitiesSigningEdxClient>(producer => producer.DefaultTopic(options.EntitiesSigningEdxRequestsTopic));

        return cluster;
    }
}
