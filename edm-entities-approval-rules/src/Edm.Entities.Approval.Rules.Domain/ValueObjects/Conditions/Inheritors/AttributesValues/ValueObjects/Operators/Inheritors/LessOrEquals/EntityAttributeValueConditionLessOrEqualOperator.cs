using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.LessOrEquals;

public sealed class EntityAttributeValueConditionLessOrEqualOperator : EntityAttributeValueConditionOperator
{
    public static readonly EntityAttributeValueConditionLessOrEqualOperator Instance = new EntityAttributeValueConditionLessOrEqualOperator();

    private EntityAttributeValueConditionLessOrEqualOperator() : base("<=")
    {
    }

    public override bool IsMet(EntityAttributeValue a, EntityAttributeValue b)
    {
        bool result = a.CompareTo(b) <= 0;

        return result;
    }
}
