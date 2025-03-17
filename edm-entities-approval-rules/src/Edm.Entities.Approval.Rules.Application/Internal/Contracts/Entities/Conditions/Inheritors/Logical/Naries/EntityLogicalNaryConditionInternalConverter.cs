using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries;

internal static class EntityLogicalNaryConditionInternalConverter
{
    internal static EntityLogicalNaryConditionInternal FromDomain(EntityLogicalNaryCondition condition)
    {
        EntityConditionOperatorInternal @operator =
            EntityConditionOperatorInternalConverter.FromDomain(condition.Operator);

        EntityConditionInternal[] innerConditions =
            condition.InnerConditions.Select(EntityConditionInternalConverter.FromDomain).ToArray();

        var result = new EntityLogicalNaryConditionInternal(@operator, innerConditions);

        return result;
    }

    internal static EntityLogicalNaryCondition ToDomain(EntityLogicalNaryConditionInternal condition)
    {
        EntityLogicalNaryConditionOperator @operator =
            EntityLogicalNaryConditionOperatorInternalConverter.ToDomain(condition.Operator);

        EntityCondition[] innerConditions =
            condition.InnerConditions.Select(EntityConditionInternalConverter.ToDomain).ToArray();

        var result = new EntityLogicalNaryCondition(@operator, innerConditions);

        return result;
    }
}
