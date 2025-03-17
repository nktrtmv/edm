namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch.Contracts;

public record ParentReferenceTypeIdToValueBff
{
    public required string ReferenceTypeId { get; init; }
    public required IReadOnlyCollection<string> Ids { get; init; }
}
