using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Equals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Greater;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.GreaterOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Less;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.LessOrEquals;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;

public static class EntityAttributeValueConditionOperatorInternal
{
    public static readonly EntityConditionOperatorInternal Equal = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.AttributeValueEqual,
        EntityAttributeValueConditionEqualOperator.Instance.DisplayName);

    public static readonly EntityConditionOperatorInternal Greater = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.AttributeValueGreater,
        EntityAttributeValueConditionGreaterOperator.Instance.DisplayName);

    public static readonly EntityConditionOperatorInternal GreaterOrEqual = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.AttributeValueGreaterOrEqual,
        EntityAttributeValueConditionGreaterOrEqualOperator.Instance.DisplayName);

    public static readonly EntityConditionOperatorInternal Less = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.AttributeValueLess,
        EntityAttributeValueConditionLessOperator.Instance.DisplayName);

    public static readonly EntityConditionOperatorInternal LessOrEqual = new EntityConditionOperatorInternal(
        EntityConditionOperatorTypeInternal.AttributeValueLessOrEqual,
        EntityAttributeValueConditionLessOrEqualOperator.Instance.DisplayName);
}
