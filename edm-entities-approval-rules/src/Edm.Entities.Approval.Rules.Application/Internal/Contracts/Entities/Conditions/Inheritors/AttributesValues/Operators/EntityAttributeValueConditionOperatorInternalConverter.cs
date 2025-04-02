using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Equals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Greater;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.GreaterOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Less;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.LessOrEquals;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;

internal static class EntityAttributeValueConditionOperatorInternalConverter
{
    internal static EntityConditionOperatorInternal FromDomain(EntityAttributeValueConditionOperator @operator)
    {
        EntityConditionOperatorInternal result = @operator switch
        {
            EntityAttributeValueConditionEqualOperator => EntityAttributeValueConditionOperatorInternal.Equal,
            EntityAttributeValueConditionGreaterOperator => EntityAttributeValueConditionOperatorInternal.Greater,
            EntityAttributeValueConditionGreaterOrEqualOperator => EntityAttributeValueConditionOperatorInternal.GreaterOrEqual,
            EntityAttributeValueConditionLessOperator => EntityAttributeValueConditionOperatorInternal.Less,
            EntityAttributeValueConditionLessOrEqualOperator => EntityAttributeValueConditionOperatorInternal.LessOrEqual,
            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }

    internal static EntityAttributeValueConditionOperator ToDomain(EntityConditionOperatorInternal @operator)
    {
        EntityAttributeValueConditionOperator result = @operator.Type switch
        {
            EntityConditionOperatorTypeInternal.AttributeValueEqual => EntityAttributeValueConditionEqualOperator.Instance,
            EntityConditionOperatorTypeInternal.AttributeValueGreater => EntityAttributeValueConditionGreaterOperator.Instance,
            EntityConditionOperatorTypeInternal.AttributeValueGreaterOrEqual => EntityAttributeValueConditionGreaterOrEqualOperator.Instance,
            EntityConditionOperatorTypeInternal.AttributeValueLess => EntityAttributeValueConditionLessOperator.Instance,
            EntityConditionOperatorTypeInternal.AttributeValueLessOrEqual => EntityAttributeValueConditionLessOrEqualOperator.Instance,
            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }
}
