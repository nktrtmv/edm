namespace Edm.DocumentGenerator.Gateway.Core.Counters.Contracts;

public sealed class DocumentCounterBff
{
    public required string Id { get; init; }
    public string? EntityTypeId { get; init; }
    public required string Name { get; init; }
    public required int Value { get; init; }
}
