namespace Edm.DocumentGenerator.Gateway.Core.References.Types.Contracts;

public sealed class ReferenceTypeBff
{
    public required string ReferenceType { get; init; }
    public string? DisplayName { get; set; }
    public required ReferenceTypeBffSearchCondition SearchCondition { get; init; }
    public required ReferenceTypeBffReferenceKind ReferenceKind { get; init; }
    public required string[] ReferenceTypes { get; init; }
    public string? ConcurrencyToken { get; init; }
}
