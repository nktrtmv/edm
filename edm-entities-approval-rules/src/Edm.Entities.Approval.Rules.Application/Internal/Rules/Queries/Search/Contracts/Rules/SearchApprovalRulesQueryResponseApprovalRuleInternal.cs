using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Rules;

public sealed class SearchApprovalRulesQueryResponseApprovalRuleInternal
{
    internal SearchApprovalRulesQueryResponseApprovalRuleInternal(
        ApprovalRuleKeyInternal key,
        string displayName,
        AuditBriefInternal<SearchApprovalRulesQueryResponseApprovalRuleInternal> audit)
    {
        Key = key;
        DisplayName = displayName;
        Audit = audit;
    }

    public ApprovalRuleKeyInternal Key { get; }
    public string DisplayName { get; }
    public AuditBriefInternal<SearchApprovalRulesQueryResponseApprovalRuleInternal> Audit { get; }
}
