namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Values;

public sealed class ApprovalReferenceValueBff
{
    public required string Id { get; init; }
    public required string DisplayValue { get; init; }
    public required string DisplaySubValue { get; init; }
}
