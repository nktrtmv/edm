namespace Edm.Entities.Signing.Workflows.GenericSubdomain.Options.Kafka;

public sealed class KafkaOptions
{
    public KafkaOptions(
        string broker,
        string publisherName,
        string consumerGroup,
        string entitiesSigningWorkflowsRequestsTopic,
        string entitiesSigningWorkflowsResultsTopic,
        string entitiesSigningWorkflowsEventsTopic,
        string entitiesSigningEdxRequestsTopic,
        string entitiesSigningEdxEventsTopic)
    {
        Broker = broker;
        PublisherName = publisherName;
        ConsumerGroup = consumerGroup;
        EntitiesSigningWorkflowsRequestsTopic = entitiesSigningWorkflowsRequestsTopic;
        EntitiesSigningWorkflowsResultsTopic = entitiesSigningWorkflowsResultsTopic;
        EntitiesSigningWorkflowsEventsTopic = entitiesSigningWorkflowsEventsTopic;
        EntitiesSigningEdxRequestsTopic = entitiesSigningEdxRequestsTopic;
        EntitiesSigningEdxEventsTopic = entitiesSigningEdxEventsTopic;
    }

    public required string Broker { get; init; }
    public required string PublisherName { get; init; }
    public required string ConsumerGroup { get; init; }

    public required string EntitiesSigningWorkflowsRequestsTopic { get; init; }
    public required string EntitiesSigningWorkflowsResultsTopic { get; init; }
    public required string EntitiesSigningWorkflowsEventsTopic { get; init; }
    public required string EntitiesSigningEdxRequestsTopic { get; init; }
    public required string EntitiesSigningEdxEventsTopic { get; init; }
}
