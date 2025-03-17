namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;

public sealed record CreateReferenceCommandBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public required string DisplayName { get; init; }
    public required string[] ReferenceTypes { get; init; }
}
