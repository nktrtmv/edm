using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Greater;

public sealed class EntityAttributeValueConditionGreaterOperator : EntityAttributeValueConditionOperator
{
    public static readonly EntityAttributeValueConditionGreaterOperator Instance = new EntityAttributeValueConditionGreaterOperator();

    private EntityAttributeValueConditionGreaterOperator() : base(">")
    {
    }

    public override bool IsMet(EntityAttributeValue a, EntityAttributeValue b)
    {
        bool result = a.CompareTo(b) > 0;

        return result;
    }
}
