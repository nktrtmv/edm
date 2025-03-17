using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;

public abstract class EntityAttributeValueConditionOperator : EntityConditionOperator
{
    protected EntityAttributeValueConditionOperator(string displayName)
        : base(displayName)
    {
    }

    public abstract bool IsMet(EntityAttributeValue a, EntityAttributeValue b);
}
