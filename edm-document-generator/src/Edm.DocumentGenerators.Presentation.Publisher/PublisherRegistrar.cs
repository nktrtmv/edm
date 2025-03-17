using Edm.DocumentGenerators.GenericSubdomain.Options.Kafka;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events;
using Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.Presentation.Publisher;

public static class PublisherRegistrar
{
    public static IClusterConfigurationBuilder ConfigurePublisher(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        services.AddSingleton<IDocumentGeneratorEventsSender, DocumentGeneratorEventsSender>();

        cluster.AddProducer<DocumentGeneratorEventsSender>(
            producer =>
                producer.DefaultTopic(options.DocumentGeneratorEventsTopic));

        return cluster;
    }
}
