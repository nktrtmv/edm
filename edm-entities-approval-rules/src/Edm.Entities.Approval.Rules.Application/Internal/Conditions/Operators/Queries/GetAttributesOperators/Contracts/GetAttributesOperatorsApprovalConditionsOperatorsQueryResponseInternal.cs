using Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts.AttributesOperators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts;

public sealed class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal
{
    internal GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseInternal(
        GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal[] attributesOperators)
    {
        AttributesOperators = attributesOperators;
    }

    public GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal[] AttributesOperators { get; }
}
