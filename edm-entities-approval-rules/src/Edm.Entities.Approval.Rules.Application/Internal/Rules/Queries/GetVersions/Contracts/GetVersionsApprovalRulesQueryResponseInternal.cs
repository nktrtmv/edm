using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.GetVersions.Contracts;

public sealed class GetVersionsApprovalRulesQueryResponseInternal
{
    internal GetVersionsApprovalRulesQueryResponseInternal(GetVersionsApprovalRulesQueryResponseApprovalRuleInternal[] rules)
    {
        Rules = rules;
    }

    public GetVersionsApprovalRulesQueryResponseApprovalRuleInternal[] Rules { get; }
}
