using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetLogicalOperators.Contracts;

internal static class GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternalConverter
{
    internal static GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal FromDomain(EntityConditionOperator[] operators)
    {
        EntityConditionOperatorInternal[] operatorsInternal =
            operators.Select(EntityConditionOperatorInternalConverter.FromDomain).ToArray();

        var result = new GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseInternal(operatorsInternal);

        return result;
    }
}
