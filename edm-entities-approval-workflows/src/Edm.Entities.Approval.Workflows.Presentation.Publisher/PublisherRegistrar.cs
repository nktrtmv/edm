using Edm.Entities.Approval.Workflows.GenericSubdomain.Options.Kafka;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Events;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Results;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher;

public static class PublisherRegistrar
{
    public static IClusterConfigurationBuilder ConfigurePublisher(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        services.AddSingleton<IEntitiesApprovalWorkflowsEventsSender, EntitiesApprovalWorkflowsEventsSender>();
        services.AddSingleton<IEntitiesApprovalWorkflowsResultsSender, EntitiesApprovalWorkflowsResultsSender>();

        cluster
            .AddProducer<EntitiesApprovalWorkflowsEventsSender>(producer => producer.DefaultTopic(options.EntitiesApprovalWorkflowsEventsTopic))
            .AddProducer<EntitiesApprovalWorkflowsResultsSender>(producer => producer.DefaultTopic(options.EntitiesApprovalWorkflowsResultsTopic));

        return cluster;
    }
}
