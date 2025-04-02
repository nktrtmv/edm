using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators.Inheritors.Nots;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries.Operators;

internal static class EntityLogicalUnaryConditionOperatorInternalConverter
{
    internal static EntityLogicalUnaryConditionOperator ToDomain(EntityConditionOperatorInternal @operator)
    {
        EntityLogicalUnaryConditionOperator result = @operator.Type switch
        {
            EntityConditionOperatorTypeInternal.LogicalUnaryNot => EntityLogicalUnaryConditionNotOperator.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }
}
