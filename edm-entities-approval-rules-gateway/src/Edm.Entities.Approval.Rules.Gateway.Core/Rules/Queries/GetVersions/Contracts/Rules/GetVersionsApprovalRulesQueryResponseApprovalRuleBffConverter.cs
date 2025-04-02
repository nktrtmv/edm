using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Contracts.Audits.Briefs;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.GetVersions.Contracts.Rules;

internal static class GetVersionsApprovalRulesQueryResponseApprovalRuleBffConverter
{
    internal static GetVersionsApprovalRulesQueryResponseApprovalRuleBff FromDto(GetVersionsApprovalRulesQueryResponseApprovalRule rule, EnrichersContext context)
    {
        var approvalRuleKey = ApprovalRuleKeyBffConverter.FromDto(rule.Key);

        var auditBrief = AuditBriefBffConverter.FromDto(rule.Audit, context);

        var result = new GetVersionsApprovalRulesQueryResponseApprovalRuleBff
        {
            ApprovalRuleKey = approvalRuleKey,
            DisplayName = rule.DisplayName,
            OriginalVersion = rule.OriginalVersion,
            AuditBrief = auditBrief,
            IsActive = rule.IsActive,
            IsReadonly = rule.IsReadonly,
            ConcurrencyToken = rule.ConcurrencyToken
        };

        return result;
    }
}
