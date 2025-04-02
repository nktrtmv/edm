using Edm.Entities.Signing.Workflows.GenericSubdomain.Options.Kafka;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher;

public static class PublisherRegistrar
{
    public static IClusterConfigurationBuilder ConfigurePublisher(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        services.AddSingleton<IEntitiesSigningWorkflowsEventsSender, EntitiesSigningWorkflowsEventsSender>();
        services.AddSingleton<IEntitiesSigningWorkflowsResultsSender, EntitiesSigningWorkflowsResultsSender>();

        cluster
            .AddProducer<EntitiesSigningWorkflowsEventsSender>(producer => producer.DefaultTopic(options.EntitiesSigningWorkflowsEventsTopic))
            .AddProducer<EntitiesSigningWorkflowsResultsSender>(producer => producer.DefaultTopic(options.EntitiesSigningWorkflowsResultsTopic));

        return cluster;
    }
}
