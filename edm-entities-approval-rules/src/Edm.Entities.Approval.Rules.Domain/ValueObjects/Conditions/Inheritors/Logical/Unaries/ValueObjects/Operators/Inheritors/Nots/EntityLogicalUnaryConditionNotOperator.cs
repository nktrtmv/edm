using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators.Inheritors.Nots;

public sealed class EntityLogicalUnaryConditionNotOperator : EntityLogicalUnaryConditionOperator
{
    public static readonly EntityLogicalUnaryConditionNotOperator Instance = new EntityLogicalUnaryConditionNotOperator();

    private EntityLogicalUnaryConditionNotOperator() : base("НЕ")
    {
    }

    public override bool IsMet(EntityCondition condition, Entity entity)
    {
        bool result = !condition.IsMet(entity);

        return result;
    }
}
