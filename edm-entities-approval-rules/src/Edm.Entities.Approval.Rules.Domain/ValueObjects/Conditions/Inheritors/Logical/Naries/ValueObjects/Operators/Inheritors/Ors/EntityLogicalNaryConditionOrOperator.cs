using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ors;

public sealed class EntityLogicalNaryConditionOrOperator : EntityLogicalNaryConditionOperator
{
    public static readonly EntityLogicalNaryConditionOrOperator Instance = new EntityLogicalNaryConditionOrOperator();

    private EntityLogicalNaryConditionOrOperator() : base("ИЛИ")
    {
    }

    public override bool IsMet(EntityCondition[] conditions, Entity entity)
    {
        bool[] results = conditions.Select(c => c.IsMet(entity)).ToArray();

        bool result = results.Any(r => r);

        return result;
    }
}
