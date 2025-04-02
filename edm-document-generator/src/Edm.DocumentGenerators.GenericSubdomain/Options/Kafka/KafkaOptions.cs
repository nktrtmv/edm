namespace Edm.DocumentGenerators.GenericSubdomain.Options.Kafka;

public sealed class KafkaOptions
{
    public KafkaOptions(
        string broker,
        string publisherName,
        string consumerGroup,
        string documentNotifierTopic,
        string entitiesApprovalWorkflowsRequestsTopic,
        string entitiesSigningWorkflowsRequestsTopic,
        string documentGeneratorEventsTopic,
        string entitiesApprovalWorkflowsResultsTopic,
        string entitiesSigningWorkflowsResultsTopic,
        string entitiesSigningWorkflowsEventsTopic)
    {
        Broker = broker;
        PublisherName = publisherName;
        ConsumerGroup = consumerGroup;
        DocumentNotifierTopic = documentNotifierTopic;
        EntitiesApprovalWorkflowsRequestsTopic = entitiesApprovalWorkflowsRequestsTopic;
        EntitiesSigningWorkflowsRequestsTopic = entitiesSigningWorkflowsRequestsTopic;
        DocumentGeneratorEventsTopic = documentGeneratorEventsTopic;
        EntitiesApprovalWorkflowsResultsTopic = entitiesApprovalWorkflowsResultsTopic;
        EntitiesSigningWorkflowsResultsTopic = entitiesSigningWorkflowsResultsTopic;
        EntitiesSigningWorkflowsEventsTopic = entitiesSigningWorkflowsEventsTopic;
    }

    public required string Broker { get; init; }
    public required string PublisherName { get; init; }
    public required string ConsumerGroup { get; init; }

    public required string DocumentNotifierTopic { get; init; }
    public required string EntitiesApprovalWorkflowsRequestsTopic { get; init; }
    public required string EntitiesSigningWorkflowsRequestsTopic { get; init; }
    public required string DocumentGeneratorEventsTopic { get; init; }
    public required string EntitiesApprovalWorkflowsResultsTopic { get; init; }
    public required string EntitiesSigningWorkflowsResultsTopic { get; init; }
    public required string EntitiesSigningWorkflowsEventsTopic { get; init; }
}
