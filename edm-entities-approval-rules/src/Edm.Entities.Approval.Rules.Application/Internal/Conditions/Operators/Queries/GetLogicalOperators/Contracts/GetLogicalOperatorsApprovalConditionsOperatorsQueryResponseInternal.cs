using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetLogicalOperators.Contracts;

public sealed class GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal
{
    internal GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal(EntityConditionOperatorInternal[] operators)
    {
        Operators = operators;
    }

    public EntityConditionOperatorInternal[] Operators { get; }
}
