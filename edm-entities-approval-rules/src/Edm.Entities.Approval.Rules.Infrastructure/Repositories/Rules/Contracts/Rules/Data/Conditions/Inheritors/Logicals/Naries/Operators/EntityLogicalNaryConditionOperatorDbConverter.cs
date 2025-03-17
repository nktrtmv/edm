using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ands;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Naries.Operators;

internal static class EntityLogicalNaryConditionOperatorDbConverter
{
    internal static EntityConditionOperatorTypeDb FromDomain(EntityLogicalNaryConditionOperator @operator)
    {
        EntityConditionOperatorTypeDb result = @operator switch
        {
            EntityLogicalNaryConditionAndOperator => EntityConditionOperatorTypeDb.LogicalNaryAnd,
            EntityLogicalNaryConditionOrOperator => EntityConditionOperatorTypeDb.LogicalNaryOr,

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }

    internal static EntityLogicalNaryConditionOperator ToDomain(EntityConditionOperatorTypeDb type)
    {
        EntityLogicalNaryConditionOperator result = type switch
        {
            EntityConditionOperatorTypeDb.LogicalNaryAnd => EntityLogicalNaryConditionAndOperator.Instance,
            EntityConditionOperatorTypeDb.LogicalNaryOr => EntityLogicalNaryConditionOrOperator.Instance,

            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
