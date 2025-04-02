namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create.Contracts;

public sealed class CreateCounterCommandBff
{
    public required string DomainId { get; init; }
    public string? EntityTypeId { get; init; }
    public required string Name { get; init; }
    public int Value { get; init; }
}
