namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Create.Contracts;

public sealed record CreateReferenceCommandResponseBff
{
    public required string ReferenceType { get; init; }
}
