using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;

public abstract class EntityLogicalNaryConditionOperator : EntityConditionOperator
{
    protected EntityLogicalNaryConditionOperator(string displayName)
        : base(displayName)
    {
    }

    public abstract bool IsMet(EntityCondition[] conditions, Entity entity);
}
