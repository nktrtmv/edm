using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Rules;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Contracts.Audits.Briefs;
using Edm.Entities.Approval.Rules.Presentation.Converters.Rules.Keys;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Rules.Converters.Queries.Search.Rules;

internal static class SearchApprovalRulesQueryResponseApprovalRuleInternalConverter
{
    internal static SearchApprovalRulesQueryResponseApprovalRule ToDto(SearchApprovalRulesQueryResponseApprovalRuleInternal rule)
    {
        ApprovalRuleKeyDto key = ApprovalRuleKeyInternalConverter.ToDto(rule.Key);

        AuditBriefDto audit = AuditBriefInternalConverter.ToDto(rule.Audit);

        var result = new SearchApprovalRulesQueryResponseApprovalRule
        {
            Key = key,
            DisplayName = rule.DisplayName,
            Audit = audit
        };

        return result;
    }
}
