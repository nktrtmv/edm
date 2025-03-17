using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.GenericSubdomain.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows;

public static class EntitiesSigningWorkflowsRegistrar
{
    public static IClusterConfigurationBuilder ConfigureEntitiesSigningWorkflows(
        this IClusterConfigurationBuilder cluster,
        IServiceCollection services,
        KafkaOptions options)
    {
        services.AddSingleton<IEntitiesSigningWorkflowsRequestsSender, EntitiesSigningWorkflowsRequestsSender>();

        cluster.AddProducer<EntitiesSigningWorkflowsRequestsSender>(producer => producer.DefaultTopic(options.EntitiesSigningWorkflowsRequestsTopic));

        return cluster;
    }
}
