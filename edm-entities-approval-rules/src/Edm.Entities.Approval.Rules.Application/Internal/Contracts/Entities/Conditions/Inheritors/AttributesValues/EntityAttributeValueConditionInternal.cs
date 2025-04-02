using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues;

public sealed class EntityAttributeValueConditionInternal : EntityConditionInternal
{
    public EntityAttributeValueConditionInternal(
        EntityConditionOperatorInternal @operator,
        EntityAttributeValueInternal attributeValue)
    {
        Operator = @operator;
        AttributeValue = attributeValue;
    }

    public EntityConditionOperatorInternal Operator { get; }
    public EntityAttributeValueInternal AttributeValue { get; }
}
