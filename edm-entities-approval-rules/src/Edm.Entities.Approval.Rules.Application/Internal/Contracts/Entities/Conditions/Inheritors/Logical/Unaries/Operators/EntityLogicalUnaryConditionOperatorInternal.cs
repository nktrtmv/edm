using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators.Inheritors.Nots;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries.Operators;

public static class EntityLogicalUnaryConditionOperatorInternal
{
    public static readonly EntityConditionOperatorInternal Not = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.LogicalUnaryNot,
        EntityLogicalUnaryConditionNotOperator.Instance.DisplayName);
}
