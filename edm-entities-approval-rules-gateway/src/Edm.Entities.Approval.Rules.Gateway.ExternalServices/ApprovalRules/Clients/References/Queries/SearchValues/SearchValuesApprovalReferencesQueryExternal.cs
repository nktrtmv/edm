using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;

public sealed class SearchValuesApprovalReferencesQueryExternal
{
    public SearchValuesApprovalReferencesQueryExternal(ApprovalReferenceKeyExternal key, string[] ids, string search, int skip, int limit)
    {
        Key = key;
        Ids = ids;
        Search = search;
        Skip = skip;
        Limit = limit;
    }

    public ApprovalReferenceKeyExternal Key { get; }
    public string[] Ids { get; }
    public string Search { get; init; }
    public int Skip { get; init; }
    public int Limit { get; init; }
}
