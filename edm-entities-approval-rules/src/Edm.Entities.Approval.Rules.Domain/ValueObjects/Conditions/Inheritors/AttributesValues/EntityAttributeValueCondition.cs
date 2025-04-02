using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;

public sealed class EntityAttributeValueCondition : EntityCondition
{
    public EntityAttributeValueCondition(EntityAttributeValueConditionOperator @operator, EntityAttributeValue attributeValue)
    {
        Operator = @operator;
        AttributeValue = attributeValue;
    }

    public EntityAttributeValueConditionOperator Operator { get; }
    public EntityAttributeValue AttributeValue { get; }

    public override bool IsMet(Entity entity)
    {
        EntityAttributeValue value = entity.GetRequiredAttributeValue(AttributeValue.Id);

        bool result = Operator.IsMet(value, AttributeValue);

        return result;
    }

    public override string ToDisplayText()
    {
        var result = $"{AttributeValue.Id} {Operator.DisplayName} {AttributeValue}";

        return result;
    }

    public override bool Equals(EntityCondition? other)
    {
        if (other is not EntityAttributeValueCondition condition)
        {
            return false;
        }

        bool result = AreTypesEqual(other) && AreConditionsEqual(condition);

        return result;
    }

    private bool AreConditionsEqual(EntityAttributeValueCondition condition)
    {
        bool areOperatorsEqual = EqualityComparer<EntityAttributeValueConditionOperator>.Default.Equals(Operator, condition.Operator);
        bool areAttributeValuesEqual = EqualityComparer<EntityAttributeValue>.Default.Equals(AttributeValue, condition.AttributeValue);

        bool result = areOperatorsEqual && areAttributeValuesEqual;

        return result;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Operator, AttributeValue);
    }

    public override string ToString()
    {
        return $"{{ {BaseToString()}, Operator: {Operator}, AttributeValue: {AttributeValue} }}";
    }
}
