using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.GenericSubdomain.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows;

public static class EntitiesApprovalWorkflowsRegistrar
{
    public static IClusterConfigurationBuilder ConfigureEntitiesApprovalWorkflows(
        this IClusterConfigurationBuilder cluster,
        IServiceCollection services,
        KafkaOptions options)
    {
        services.AddSingleton<IEntitiesApprovalWorkflowsRequestsSender, EntitiesApprovalWorkflowsRequestsSender>();

        cluster.AddProducer<EntitiesApprovalWorkflowsRequestsSender>(producer => producer.DefaultTopic(options.EntitiesApprovalWorkflowsRequestsTopic));

        return cluster;
    }
}
