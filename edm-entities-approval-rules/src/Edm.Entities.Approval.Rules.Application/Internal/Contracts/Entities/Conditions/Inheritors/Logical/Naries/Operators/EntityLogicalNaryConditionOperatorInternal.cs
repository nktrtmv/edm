using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ands;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators.Inheritors.Ors;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries.Operators;

public static class EntityLogicalNaryConditionOperatorInternal
{
    public static readonly EntityConditionOperatorInternal And = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.LogicalNaryAnd,
        EntityLogicalNaryConditionAndOperator.Instance.DisplayName);

    public static readonly EntityConditionOperatorInternal Or = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.LogicalNaryOr,
        EntityLogicalNaryConditionOrOperator.Instance.DisplayName);
}
