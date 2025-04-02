using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Rules;

internal static class SearchApprovalRulesQueryResponseApprovalRuleInternalConverter
{
    internal static SearchApprovalRulesQueryResponseApprovalRuleInternal FromDomain(ApprovalRule rule)
    {
        ApprovalRuleKeyInternal key = ApprovalRuleKeyInternalConverter.FromDomain(rule);

        AuditBriefInternal<SearchApprovalRulesQueryResponseApprovalRuleInternal> audit =
            AuditBriefInternalConverterFrom<SearchApprovalRulesQueryResponseApprovalRuleInternal>.FromDomain(rule.Audit.Brief);

        var result = new SearchApprovalRulesQueryResponseApprovalRuleInternal(key, rule.EntityType.DisplayName, audit);

        return result;
    }
}
