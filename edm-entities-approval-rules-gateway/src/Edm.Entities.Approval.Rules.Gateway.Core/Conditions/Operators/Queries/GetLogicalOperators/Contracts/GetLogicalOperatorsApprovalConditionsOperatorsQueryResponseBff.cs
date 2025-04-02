using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetLogicalOperators.Contracts;

public sealed class GetLogicalOperatorsApprovalConditionsOperatorsQueryResponseBff
{
    public required EntityConditionOperatorBff[] Operators { get; init; }
}
