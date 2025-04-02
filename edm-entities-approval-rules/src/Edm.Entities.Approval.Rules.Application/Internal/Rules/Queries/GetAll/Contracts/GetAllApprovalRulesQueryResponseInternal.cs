using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetAll.Contracts;

public sealed class GetAllApprovalRulesQueryResponseInternal
{
    internal GetAllApprovalRulesQueryResponseInternal(GetAllApprovalRulesQueryResponseApprovalRuleInternal[] rules)
    {
        Rules = rules;
    }

    public GetAllApprovalRulesQueryResponseApprovalRuleInternal[] Rules { get; }
}
