using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;

internal static class GetAllApprovalRulesQueryResponseInternalConverter
{
    internal static GetAllApprovalRulesQueryResponseInternal FromDomain(ApprovalRule[] rules)
    {
        GetAllApprovalRulesQueryResponseApprovalRuleInternal[] rulesInternal =
            rules.Select(GetAllApprovalRulesQueryResponseApprovalRuleInternalConverter.FromDomain).ToArray();

        var result = new GetAllApprovalRulesQueryResponseInternal(rulesInternal);

        return result;
    }
}
