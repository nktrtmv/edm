using Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.Core.References.Queries.SearchValues.Contracts;

public sealed class SearchValuesApprovalReferencesQueryBff
{
    public required ApprovalReferenceKeyBff Key { get; init; }
    public string[] Ids { get; init; } = Array.Empty<string>();
    public string Search { get; init; } = string.Empty;
    public int Skip { get; init; } = 0;
    public int Limit { get; init; } = int.MaxValue;
}
