namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Commands.Update.Contracts;

public sealed record UpdateReferenceCommandBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public string? DisplayName { get; set; }
    public required string[] ReferenceTypes { get; init; }
    public required string ConcurrencyToken { get; init; }
}
