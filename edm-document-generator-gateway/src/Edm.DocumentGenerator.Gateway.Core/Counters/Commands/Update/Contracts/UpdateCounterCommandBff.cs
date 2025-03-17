namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update.Contracts;

public sealed class UpdateCounterCommandBff
{
    public required string Id { get; init; }
    public required string DomainId { get; init; }
    public string? EntityTypeId { get; init; }
    public required string Name { get; init; }
    public int Value { get; init; }
}
