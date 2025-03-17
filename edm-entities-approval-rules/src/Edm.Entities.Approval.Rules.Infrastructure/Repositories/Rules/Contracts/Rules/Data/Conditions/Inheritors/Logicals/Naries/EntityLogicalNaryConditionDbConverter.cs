using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Naries.Operators;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Naries;

internal static class EntityLogicalNaryConditionDbConverter
{
    internal static EntityLogicalNaryCondition ToDomain(EntityLogicalNaryConditionDb condition)
    {
        EntityLogicalNaryConditionOperator @operator =
            EntityLogicalNaryConditionOperatorDbConverter.ToDomain(condition.Operator);

        EntityCondition[] innerConditions =
            condition.InnerConditions.Select(EntityConditionDbConverter.ToDomain).ToArray();

        var result = new EntityLogicalNaryCondition(@operator, innerConditions);

        return result;
    }

    internal static EntityLogicalNaryConditionDb FromDomain(EntityLogicalNaryCondition condition)
    {
        EntityConditionOperatorTypeDb @operator =
            EntityLogicalNaryConditionOperatorDbConverter.FromDomain(condition.Operator);

        EntityConditionDb[] innerConditions =
            condition.InnerConditions.Select(EntityConditionDbConverter.FromDomain).ToArray();

        var result = new EntityLogicalNaryConditionDb
        {
            Operator = @operator,
            InnerConditions = { innerConditions }
        };

        return result;
    }
}
