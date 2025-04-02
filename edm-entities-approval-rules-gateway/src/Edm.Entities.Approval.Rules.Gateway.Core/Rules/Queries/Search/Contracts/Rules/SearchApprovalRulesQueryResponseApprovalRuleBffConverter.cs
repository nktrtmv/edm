using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Contracts.Audits.Briefs;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Enrichers;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Queries.Search.Contracts.Rules;

internal static class SearchApprovalRulesQueryResponseApprovalRuleBffConverter
{
    internal static SearchApprovalRulesQueryResponseApprovalRuleBff FromDto(
        SearchApprovalRulesQueryResponseApprovalRule rule,
        EnrichersContext context)
    {
        var key = ApprovalRuleKeyBffConverter.FromDto(rule.Key);

        var audit = AuditBriefBffConverter.FromDto(rule.Audit, context);

        var result = new SearchApprovalRulesQueryResponseApprovalRuleBff
        {
            Key = key,
            DisplayName = rule.DisplayName,
            Audit = audit
        };

        return result;
    }
}
