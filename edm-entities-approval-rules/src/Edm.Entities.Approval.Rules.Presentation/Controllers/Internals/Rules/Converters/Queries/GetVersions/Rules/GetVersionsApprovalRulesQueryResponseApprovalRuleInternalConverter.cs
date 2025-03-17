using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts.Rules;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Contracts.Audits.Briefs;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.GetVersions.Rules;

internal static class GetVersionsApprovalRulesQueryResponseApprovalRuleInternalConverter
{
    internal static GetVersionsApprovalRulesQueryResponseApprovalRule ToDto(GetVersionsApprovalRulesQueryResponseApprovalRuleInternal rule)
    {
        ApprovalRuleKeyDto key = ApprovalRuleKeyInternalConverter.ToDto(rule.ApprovalRuleKey);

        AuditBriefDto audit = AuditBriefInternalConverter.ToDto(rule.Audit);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(rule.ConcurrencyToken);

        var result = new GetVersionsApprovalRulesQueryResponseApprovalRule
        {
            Key = key,
            DisplayName = rule.DisplayName,
            OriginalVersion = rule.OriginalVersion,
            Audit = audit,
            IsActive = rule.IsActive,
            IsReadonly = rule.IsReadonly,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
