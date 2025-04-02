using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Contracts.Audits.Briefs;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Rules;

public sealed class SearchApprovalRulesQueryResponseApprovalRuleBff
{
    public required ApprovalRuleKeyBff Key { get; init; }
    public required string DisplayName { get; init; }
    public required AuditBriefBff Audit { get; init; }
}
