using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests;
using Edm.DocumentGenerators.GenericSubdomain.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.ExternalServices.DocumentsNotifier;

public static class DocumentNotifierRegistrar
{
    public static IClusterConfigurationBuilder ConfigureDocumentNotifier(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        services.AddSingleton<IDocumentNotifierRequestsSender, DocumentNotifierRequestsSender>();

        cluster.AddProducer<DocumentNotifierRequestsSender>(producer => producer.DefaultTopic(options.DocumentNotifierTopic));

        return cluster;
    }
}
