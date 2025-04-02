using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.GreaterOrEquals;

public sealed class EntityAttributeValueConditionGreaterOrEqualOperator : EntityAttributeValueConditionOperator
{
    public static readonly EntityAttributeValueConditionGreaterOrEqualOperator Instance = new EntityAttributeValueConditionGreaterOrEqualOperator();

    private EntityAttributeValueConditionGreaterOrEqualOperator() : base(">=")
    {
    }

    public override bool IsMet(EntityAttributeValue a, EntityAttributeValue b)
    {
        bool result = a.CompareTo(b) >= 0;

        return result;
    }
}
