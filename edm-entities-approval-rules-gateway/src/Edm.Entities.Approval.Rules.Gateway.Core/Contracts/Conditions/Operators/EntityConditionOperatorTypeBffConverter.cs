using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

internal static class EntityConditionOperatorTypeBffConverter
{
    internal static EntityConditionOperatorTypeBff FromDto(EntityConditionOperatorTypeDto type)
    {
        var result = type switch
        {
            EntityConditionOperatorTypeDto.AttributeValueEqual => EntityConditionOperatorTypeBff.AttributeValueEqual,
            EntityConditionOperatorTypeDto.AttributeValueGreater => EntityConditionOperatorTypeBff.AttributeValueGreater,
            EntityConditionOperatorTypeDto.AttributeValueGreaterOrEqual => EntityConditionOperatorTypeBff.AttributeValueGreaterOrEqual,
            EntityConditionOperatorTypeDto.AttributeValueLess => EntityConditionOperatorTypeBff.AttributeValueLess,
            EntityConditionOperatorTypeDto.AttributeValueLessOrEqual => EntityConditionOperatorTypeBff.AttributeValueLessOrEqual,
            EntityConditionOperatorTypeDto.LogicalNaryAnd => EntityConditionOperatorTypeBff.LogicalNaryAnd,
            EntityConditionOperatorTypeDto.LogicalNaryOr => EntityConditionOperatorTypeBff.LogicalNaryOr,
            EntityConditionOperatorTypeDto.LogicalUnaryNot => EntityConditionOperatorTypeBff.LogicalUnaryNot,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static EntityConditionOperatorTypeDto ToDto(EntityConditionOperatorTypeBff type)
    {
        var result = type switch
        {
            EntityConditionOperatorTypeBff.AttributeValueEqual => EntityConditionOperatorTypeDto.AttributeValueEqual,
            EntityConditionOperatorTypeBff.AttributeValueGreater => EntityConditionOperatorTypeDto.AttributeValueGreater,
            EntityConditionOperatorTypeBff.AttributeValueGreaterOrEqual => EntityConditionOperatorTypeDto.AttributeValueGreaterOrEqual,
            EntityConditionOperatorTypeBff.AttributeValueLess => EntityConditionOperatorTypeDto.AttributeValueLess,
            EntityConditionOperatorTypeBff.AttributeValueLessOrEqual => EntityConditionOperatorTypeDto.AttributeValueLessOrEqual,
            EntityConditionOperatorTypeBff.LogicalNaryAnd => EntityConditionOperatorTypeDto.LogicalNaryAnd,
            EntityConditionOperatorTypeBff.LogicalNaryOr => EntityConditionOperatorTypeDto.LogicalNaryOr,
            EntityConditionOperatorTypeBff.LogicalUnaryNot => EntityConditionOperatorTypeDto.LogicalUnaryNot,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
