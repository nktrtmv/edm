using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Equals;

public sealed class EntityAttributeValueConditionEqualOperator : EntityAttributeValueConditionOperator
{
    public static readonly EntityAttributeValueConditionEqualOperator Instance = new EntityAttributeValueConditionEqualOperator();

    private EntityAttributeValueConditionEqualOperator() : base("=")
    {
    }

    public override bool IsMet(EntityAttributeValue a, EntityAttributeValue b)
    {
        bool result = a.Equals(b);

        return result;
    }
}
