using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.AttributesValues.Operators;

internal static class EntityConditionOperatorInternalConverter
{
    internal static EntityConditionOperatorInternal FromDto(EntityConditionOperatorDto @operator)
    {
        EntityConditionOperatorInternal result = @operator.Type switch
        {
            EntityConditionOperatorTypeDto.AttributeValueEqual =>
                EntityAttributeValueConditionOperatorInternal.Equal,

            EntityConditionOperatorTypeDto.AttributeValueGreater =>
                EntityAttributeValueConditionOperatorInternal.Greater,

            EntityConditionOperatorTypeDto.AttributeValueGreaterOrEqual =>
                EntityAttributeValueConditionOperatorInternal.GreaterOrEqual,

            EntityConditionOperatorTypeDto.AttributeValueLess =>
                EntityAttributeValueConditionOperatorInternal.Less,

            EntityConditionOperatorTypeDto.AttributeValueLessOrEqual =>
                EntityAttributeValueConditionOperatorInternal.LessOrEqual,

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }

    internal static EntityConditionOperatorDto ToDto(EntityConditionOperatorInternal @operator)
    {
        string displayName = @operator.DisplayName;

        EntityConditionOperatorDto result = @operator.Type switch
        {
            EntityConditionOperatorTypeInternal.AttributeValueEqual =>
                ToDto(EntityConditionOperatorTypeDto.AttributeValueEqual, displayName),

            EntityConditionOperatorTypeInternal.AttributeValueGreater =>
                ToDto(EntityConditionOperatorTypeDto.AttributeValueGreater, displayName),

            EntityConditionOperatorTypeInternal.AttributeValueGreaterOrEqual =>
                ToDto(EntityConditionOperatorTypeDto.AttributeValueGreaterOrEqual, displayName),

            EntityConditionOperatorTypeInternal.AttributeValueLess =>
                ToDto(EntityConditionOperatorTypeDto.AttributeValueLess, displayName),

            EntityConditionOperatorTypeInternal.AttributeValueLessOrEqual =>
                ToDto(EntityConditionOperatorTypeDto.AttributeValueLessOrEqual, displayName),

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        result.DisplayName = @operator.DisplayName;

        return result;
    }

    private static EntityConditionOperatorDto ToDto(EntityConditionOperatorTypeDto type, string displayName)
    {
        var result = new EntityConditionOperatorDto
        {
            Kind = EntityConditionOperatorKindDto.AttributeValue,
            Type = type,
            DisplayName = displayName
        };

        return result;
    }
}
