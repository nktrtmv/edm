namespace Edm.DocumentGenerator.Gateway.Core.DocumentClassifiers.Queries.GetBusinessSegments.Contracts;

public sealed class BusinessSegmentBff
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
}
