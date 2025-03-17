using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Contracts.Audits.Briefs;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts.Rules;

public sealed class GetVersionsApprovalRulesQueryResponseApprovalRuleBff
{
    public required ApprovalRuleKeyBff ApprovalRuleKey { get; init; }
    public required string DisplayName { get; init; }
    public required int OriginalVersion { get; init; }
    public required AuditBriefBff AuditBrief { get; init; }
    public required bool IsActive { get; init; }
    public required bool IsReadonly { get; init; }
    public required string ConcurrencyToken { get; init; }
}
