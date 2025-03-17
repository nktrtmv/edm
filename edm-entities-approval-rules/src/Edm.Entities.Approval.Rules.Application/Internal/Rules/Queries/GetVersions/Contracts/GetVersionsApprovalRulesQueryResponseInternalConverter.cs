using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;

internal static class GetVersionsApprovalRulesQueryResponseInternalConverter
{
    internal static GetVersionsApprovalRulesQueryResponseInternal FromDomain(ApprovalRule[] rules)
    {
        GetVersionsApprovalRulesQueryResponseApprovalRuleInternal[] rulesInternal =
            rules.Select(GetVersionsApprovalRulesQueryResponseApprovalRuleInternalConverter.FromDomain).ToArray();

        var result = new GetVersionsApprovalRulesQueryResponseInternal(rulesInternal);

        return result;
    }
}
