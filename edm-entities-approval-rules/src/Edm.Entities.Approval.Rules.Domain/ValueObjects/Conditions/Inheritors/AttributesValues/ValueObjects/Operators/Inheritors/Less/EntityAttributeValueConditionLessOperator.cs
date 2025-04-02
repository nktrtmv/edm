using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Less;

public sealed class EntityAttributeValueConditionLessOperator : EntityAttributeValueConditionOperator
{
    public static readonly EntityAttributeValueConditionLessOperator Instance = new EntityAttributeValueConditionLessOperator();

    private EntityAttributeValueConditionLessOperator() : base("<")
    {
    }

    public override bool IsMet(EntityAttributeValue a, EntityAttributeValue b)
    {
        bool result = a.CompareTo(b) < 0;

        return result;
    }
}
