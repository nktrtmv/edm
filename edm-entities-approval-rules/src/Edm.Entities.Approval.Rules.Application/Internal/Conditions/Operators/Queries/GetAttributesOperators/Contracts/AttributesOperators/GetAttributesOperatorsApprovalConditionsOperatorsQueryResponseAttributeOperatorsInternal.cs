using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;

namespace Edm.Entities.Approval.Rules.Application.Internal.Conditions.Operators.Queries.GetAttributesOperators.Contracts.AttributesOperators;

public sealed class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal
{
    internal GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsInternal(
        EntityTypeAttributeInternal attribute,
        EntityConditionOperatorInternal[] operators)
    {
        Attribute = attribute;
        Operators = operators;
    }

    public EntityTypeAttributeInternal Attribute { get; }
    public EntityConditionOperatorInternal[] Operators { get; }
}
