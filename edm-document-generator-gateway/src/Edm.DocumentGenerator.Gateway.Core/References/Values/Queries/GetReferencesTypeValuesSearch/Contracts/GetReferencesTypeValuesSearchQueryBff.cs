namespace Edm.DocumentGenerator.Gateway.Core.References.Values.Queries.GetReferencesTypeValuesSearch.Contracts;

public sealed record GetReferencesTypeValuesSearchQueryBff
{
    public required string ReferenceType { get; init; }
    public string[] Ids { get; init; } = Array.Empty<string>();
    public required string Query { get; init; }
    public int Skip { get; init; }
    public int? Limit { get; init; }
    public IReadOnlyCollection<ParentReferenceTypeIdToValueBff>? ParentReferenceTypeIdToValues { get; init; } = Array.Empty<ParentReferenceTypeIdToValueBff>();
    public string? TemplateId { get; set; }
}
