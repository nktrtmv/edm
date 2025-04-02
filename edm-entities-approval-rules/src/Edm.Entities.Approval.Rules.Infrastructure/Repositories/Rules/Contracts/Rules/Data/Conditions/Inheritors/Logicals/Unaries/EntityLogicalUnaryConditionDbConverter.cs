using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Unaries.Operators;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Unaries;

internal static class EntityLogicalUnaryConditionDbConverter
{
    internal static EntityLogicalUnaryCondition ToDomain(EntityLogicalUnaryConditionDb condition)
    {
        EntityLogicalUnaryConditionOperator @operator =
            EntityUnaryConditionOperatorDbConverter.ToDomain(condition.Operator);

        EntityCondition innerCondition =
            EntityConditionDbConverter.ToDomain(condition.InnerCondition);

        var result = new EntityLogicalUnaryCondition(@operator, innerCondition);

        return result;
    }

    internal static EntityLogicalUnaryConditionDb FromDomain(EntityLogicalUnaryCondition condition)
    {
        EntityConditionOperatorTypeDb @operator =
            EntityUnaryConditionOperatorDbConverter.FromDomain(condition.Operator);

        EntityConditionDb innerCondition =
            EntityConditionDbConverter.FromDomain(condition.InnerCondition);

        var result = new EntityLogicalUnaryConditionDb
        {
            Operator = @operator,
            InnerCondition = innerCondition
        };

        return result;
    }
}
