using Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Queries.Search.Contracts;

public sealed class SearchApprovalRulesQueryResponseInternal
{
    internal SearchApprovalRulesQueryResponseInternal(SearchApprovalRulesQueryResponseApprovalRuleInternal[] rules)
    {
        Rules = rules;
    }

    public SearchApprovalRulesQueryResponseApprovalRuleInternal[] Rules { get; }
}
