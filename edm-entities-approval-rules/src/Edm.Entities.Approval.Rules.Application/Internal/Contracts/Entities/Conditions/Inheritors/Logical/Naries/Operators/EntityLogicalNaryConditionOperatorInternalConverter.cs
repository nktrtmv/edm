using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ands;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ors;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries.Operators;

internal static class EntityLogicalNaryConditionOperatorInternalConverter
{
    internal static EntityLogicalNaryConditionOperator ToDomain(EntityConditionOperatorInternal @operator)
    {
        EntityLogicalNaryConditionOperator result = @operator.Type switch
        {
            EntityConditionOperatorTypeInternal.LogicalNaryAnd => EntityLogicalNaryConditionAndOperator.Instance,
            EntityConditionOperatorTypeInternal.LogicalNaryOr => EntityLogicalNaryConditionOrOperator.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }
}
