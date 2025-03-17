using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries;

internal static class EntityLogicalUnaryConditionInternalConverter
{
    internal static EntityLogicalUnaryConditionInternal FromDomain(EntityLogicalUnaryCondition condition)
    {
        EntityConditionOperatorInternal @operator =
            EntityConditionOperatorInternalConverter.FromDomain(condition.Operator);

        EntityConditionInternal innerCondition =
            EntityConditionInternalConverter.FromDomain(condition.InnerCondition);

        var result = new EntityLogicalUnaryConditionInternal(@operator, innerCondition);

        return result;
    }

    internal static EntityLogicalUnaryCondition ToDomain(EntityLogicalUnaryConditionInternal condition)
    {
        EntityLogicalUnaryConditionOperator @operator =
            EntityLogicalUnaryConditionOperatorInternalConverter.ToDomain(condition.Operator);

        EntityCondition innerCondition =
            EntityConditionInternalConverter.ToDomain(condition.InnerCondition);

        var result = new EntityLogicalUnaryCondition(@operator, innerCondition);

        return result;
    }
}
