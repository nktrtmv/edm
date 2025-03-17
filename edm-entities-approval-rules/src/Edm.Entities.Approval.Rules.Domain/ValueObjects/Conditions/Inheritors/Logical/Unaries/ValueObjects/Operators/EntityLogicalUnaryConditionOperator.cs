using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;

public abstract class EntityLogicalUnaryConditionOperator : EntityConditionOperator
{
    protected EntityLogicalUnaryConditionOperator(string displayName)
        : base(displayName)
    {
    }

    public abstract bool IsMet(EntityCondition condition, Entity entity);
}
