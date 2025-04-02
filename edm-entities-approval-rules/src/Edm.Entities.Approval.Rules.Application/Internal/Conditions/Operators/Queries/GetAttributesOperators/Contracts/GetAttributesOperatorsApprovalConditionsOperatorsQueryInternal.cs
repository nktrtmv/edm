using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;

public sealed class GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal
    : IRequest<GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal>
{
    public GetAttributesOperatorsApprovalConditionsOperatorsQueryInternal(ApprovalRuleKeyInternal approvalRuleKey)
    {
        ApprovalRuleKey = approvalRuleKey;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
}
