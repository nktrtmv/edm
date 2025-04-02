namespace Edm.Entities.Approval.Workflows.GenericSubdomain.Options.Kafka;

public sealed class KafkaOptions
{
    public KafkaOptions(
        string broker,
        string publisherName,
        string consumerGroup,
        string entitiesApprovalWorkflowsEventsTopic,
        string entitiesApprovalWorkflowsRequestsTopic,
        string entitiesApprovalWorkflowsResultsTopic)
    {
        Broker = broker;
        PublisherName = publisherName;
        ConsumerGroup = consumerGroup;
        EntitiesApprovalWorkflowsEventsTopic = entitiesApprovalWorkflowsEventsTopic;
        EntitiesApprovalWorkflowsRequestsTopic = entitiesApprovalWorkflowsRequestsTopic;
        EntitiesApprovalWorkflowsResultsTopic = entitiesApprovalWorkflowsResultsTopic;
    }

    public required string Broker { get; init; }
    public required string PublisherName { get; init; }
    public required string ConsumerGroup { get; init; }

    public required string EntitiesApprovalWorkflowsEventsTopic { get; init; }
    public required string EntitiesApprovalWorkflowsRequestsTopic { get; init; }
    public required string EntitiesApprovalWorkflowsResultsTopic { get; init; }
}
