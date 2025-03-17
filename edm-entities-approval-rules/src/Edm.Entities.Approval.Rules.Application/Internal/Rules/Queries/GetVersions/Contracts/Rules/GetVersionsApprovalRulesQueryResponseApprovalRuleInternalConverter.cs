using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain.Audits.Application.Briefs;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts.Rules;

internal static class GetVersionsApprovalRulesQueryResponseApprovalRuleInternalConverter
{
    internal static GetVersionsApprovalRulesQueryResponseApprovalRuleInternal FromDomain(ApprovalRule rule)
    {
        ApprovalRuleKeyInternal approvalRuleKey = ApprovalRuleKeyInternalConverter.FromDomain(rule);

        AuditBriefInternal<GetVersionsApprovalRulesQueryResponseApprovalRuleInternal> audit =
            AuditBriefInternalConverterFrom<GetVersionsApprovalRulesQueryResponseApprovalRuleInternal>.FromDomain(rule.Audit.Brief);

        bool isReadonly = rule.HasBeenActivated || rule.IsDeleted;

        ConcurrencyToken<GetVersionsApprovalRulesQueryResponseApprovalRuleInternal> concurrencyToken =
            ConcurrencyTokenConverterFrom<GetVersionsApprovalRulesQueryResponseApprovalRuleInternal>.From(rule.ConcurrencyToken);

        var result = new GetVersionsApprovalRulesQueryResponseApprovalRuleInternal(
            approvalRuleKey,
            rule.EntityType.DisplayName,
            rule.OriginalVersion,
            audit,
            rule.IsActive,
            isReadonly,
            concurrencyToken);

        return result;
    }
}
