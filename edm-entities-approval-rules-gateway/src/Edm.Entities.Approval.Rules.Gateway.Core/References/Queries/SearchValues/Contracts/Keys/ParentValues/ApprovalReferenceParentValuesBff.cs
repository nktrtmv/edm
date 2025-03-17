namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys.ParentValues;

public sealed class ApprovalReferenceParentValuesBff
{
    public required string ReferenceTypeId { get; init; }
    public required string[] Ids { get; init; }
}
