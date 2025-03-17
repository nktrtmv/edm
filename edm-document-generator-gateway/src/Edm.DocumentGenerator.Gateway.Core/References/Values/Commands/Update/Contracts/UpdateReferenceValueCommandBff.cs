namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Update.Contracts;

public sealed record UpdateReferenceValueCommandBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public required string Id { get; init; }
    public string? NewId { get; init; }
    public required string DisplayValue { get; set; }
    public required string DisplaySubValue { get; set; }
    public required bool IsHidden { get; set; }
    public required string ConcurrencyToken { get; init; }
}
