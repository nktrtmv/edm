using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Keys;
using Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues.Contracts.Values;

namespace Edm.Entities.Approval.Rules.Gateway.ExternalServices.ApprovalRules.Clients.References.Queries.SearchValues;

public sealed class SearchValuesApprovalReferencesQueryResponseExternal
{
    public SearchValuesApprovalReferencesQueryResponseExternal(
        ApprovalReferenceKeyExternal key,
        ApprovalReferenceValueExternal[] values)
    {
        Key = key;
        Values = values;
    }

    public ApprovalReferenceKeyExternal Key { get; }
    public ApprovalReferenceValueExternal[] Values { get; }
}
