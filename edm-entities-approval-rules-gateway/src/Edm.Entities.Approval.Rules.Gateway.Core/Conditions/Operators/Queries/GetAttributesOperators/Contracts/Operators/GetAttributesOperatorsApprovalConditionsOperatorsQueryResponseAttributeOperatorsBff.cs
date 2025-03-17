using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.EntitiesTypes.Attributes;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators.Queries.GetAttributesOperators.Contracts.Operators;

public sealed class GetAttributesOperatorsApprovalConditionsOperatorsQueryResponseAttributeOperatorsBff
{
    public required EntityTypeAttributeBff Attribute { get; init; }
    public required EntityConditionOperatorBff[] Operators { get; init; }
}
