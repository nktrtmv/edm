using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.AttributeValue;

public sealed class EntityAttributeValueConditionBff : EntityConditionBff
{
    public required EntityConditionOperatorBff Operator { get; init; }
    public required EntityAttributeValueBff AttributeValue { get; init; }
}
