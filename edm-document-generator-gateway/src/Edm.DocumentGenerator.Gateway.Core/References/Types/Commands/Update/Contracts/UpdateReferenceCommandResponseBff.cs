namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;

public sealed record UpdateReferenceCommandResponseBff
{
    public required string ReferenceType { get; init; }
}
