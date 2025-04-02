using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ands;

public sealed class EntityLogicalNaryConditionAndOperator : EntityLogicalNaryConditionOperator
{
    public static readonly EntityLogicalNaryConditionAndOperator Instance = new EntityLogicalNaryConditionAndOperator();

    private EntityLogicalNaryConditionAndOperator() : base("И")
    {
    }

    public override bool IsMet(EntityCondition[] conditions, Entity entity)
    {
        bool result = conditions.All(condition => condition.IsMet(entity));

        return result;
    }
}
