using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators.Inheritors.Nots;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.Logicals.Unaries.Operators;

internal static class EntityUnaryConditionOperatorDbConverter
{
    internal static EntityConditionOperatorTypeDb FromDomain(EntityLogicalUnaryConditionOperator @operator)
    {
        EntityConditionOperatorTypeDb result = @operator switch
        {
            EntityLogicalUnaryConditionNotOperator => EntityConditionOperatorTypeDb.LogicalUnaryNot,

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }

    internal static EntityLogicalUnaryConditionOperator ToDomain(EntityConditionOperatorTypeDb type)
    {
        EntityLogicalUnaryConditionOperator result = type switch
        {
            EntityConditionOperatorTypeDb.LogicalUnaryNot => EntityLogicalUnaryConditionNotOperator.Instance,

            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
