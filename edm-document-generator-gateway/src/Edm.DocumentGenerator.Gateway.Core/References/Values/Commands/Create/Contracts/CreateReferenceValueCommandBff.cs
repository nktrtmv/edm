namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Commands.Create.Contracts;

public sealed record CreateReferenceValueCommandBff
{
    public required string DomainId { get; init; }
    public required string ReferenceType { get; init; }
    public string? Id { get; init; }
    public required string DisplayValue { get; set; }
    public required string DisplaySubValue { get; set; }
    public required bool IsHidden { get; set; }
}
