using Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts.Operators;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts;

public sealed class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseBff
{
    public required GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBff[] AttributesOperators { get; init; }
}
