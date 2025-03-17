namespace Edm.Document.Searcher.GenericSubdomain.Options.Kafka;

public sealed class KafkaOptions
{
    public KafkaOptions(
        string broker,
        string publisherName,
        string consumerGroup,
        string documentSearcherEventsTopic,
        string edmDocumentGeneratorEventsTopic,
        string edmEntitiesApprovalWorkflowsEventsTopic,
        string edmEntitiesSigningWorkflowsEventsTopic)
    {
        Broker = broker;
        PublisherName = publisherName;
        ConsumerGroup = consumerGroup;
        DocumentSearcherEventsTopic = documentSearcherEventsTopic;
        EdmDocumentGeneratorEventsTopic = edmDocumentGeneratorEventsTopic;
        EdmEntitiesApprovalWorkflowsEventsTopic = edmEntitiesApprovalWorkflowsEventsTopic;
        EdmEntitiesSigningWorkflowsEventsTopic = edmEntitiesSigningWorkflowsEventsTopic;
    }

    public required string Broker { get; init; }
    public required string PublisherName { get; init; }
    public required string ConsumerGroup { get; init; }

    public required string DocumentSearcherEventsTopic { get; init; }
    public required string EdmDocumentGeneratorEventsTopic { get; init; }
    public required string EdmEntitiesApprovalWorkflowsEventsTopic { get; init; }
    public required string EdmEntitiesSigningWorkflowsEventsTopic { get; init; }
}
