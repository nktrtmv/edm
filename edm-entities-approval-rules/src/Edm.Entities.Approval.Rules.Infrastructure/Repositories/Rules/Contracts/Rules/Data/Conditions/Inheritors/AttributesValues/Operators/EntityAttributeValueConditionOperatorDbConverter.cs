using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Equals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Greater;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.GreaterOrEquals;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.Less;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators.Inheritors.LessOrEquals;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.AttributesValues.Operators;

internal static class EntityAttributeValueConditionOperatorDbConverter
{
    internal static EntityConditionOperatorTypeDb FromDomain(EntityAttributeValueConditionOperator @operator)
    {
        EntityConditionOperatorTypeDb result = @operator switch
        {
            EntityAttributeValueConditionEqualOperator => EntityConditionOperatorTypeDb.AttributeValueEqual,
            EntityAttributeValueConditionGreaterOperator => EntityConditionOperatorTypeDb.AttributeValueGreater,
            EntityAttributeValueConditionGreaterOrEqualOperator => EntityConditionOperatorTypeDb.AttributeValueGreaterOrEqual,
            EntityAttributeValueConditionLessOperator => EntityConditionOperatorTypeDb.AttributeValueLess,
            EntityAttributeValueConditionLessOrEqualOperator => EntityConditionOperatorTypeDb.AttributeValueLessOrEqual,

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }

    internal static EntityAttributeValueConditionOperator ToDomain(EntityConditionOperatorTypeDb type)
    {
        EntityAttributeValueConditionOperator result = type switch
        {
            EntityConditionOperatorTypeDb.AttributeValueEqual => EntityAttributeValueConditionEqualOperator.Instance,
            EntityConditionOperatorTypeDb.AttributeValueGreater => EntityAttributeValueConditionGreaterOperator.Instance,
            EntityConditionOperatorTypeDb.AttributeValueGreaterOrEqual => EntityAttributeValueConditionGreaterOrEqualOperator.Instance,
            EntityConditionOperatorTypeDb.AttributeValueLess => EntityAttributeValueConditionLessOperator.Instance,
            EntityConditionOperatorTypeDb.AttributeValueLessOrEqual => EntityAttributeValueConditionLessOrEqualOperator.Instance,

            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
