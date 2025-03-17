using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators.Kinds;

internal static class EntityConditionOperatorKindDtoConverter
{
    internal static EntityConditionOperatorKindDto FromInternal(EntityConditionOperatorTypeInternal type)
    {
        EntityConditionOperatorKindDto result = type switch
        {
            EntityConditionOperatorTypeInternal.AttributeValueEqual => EntityConditionOperatorKindDto.AttributeValue,
            EntityConditionOperatorTypeInternal.AttributeValueGreater => EntityConditionOperatorKindDto.AttributeValue,
            EntityConditionOperatorTypeInternal.AttributeValueGreaterOrEqual => EntityConditionOperatorKindDto.AttributeValue,
            EntityConditionOperatorTypeInternal.AttributeValueLess => EntityConditionOperatorKindDto.AttributeValue,
            EntityConditionOperatorTypeInternal.AttributeValueLessOrEqual => EntityConditionOperatorKindDto.AttributeValue,

            EntityConditionOperatorTypeInternal.LogicalNaryAnd => EntityConditionOperatorKindDto.LogicalNary,
            EntityConditionOperatorTypeInternal.LogicalNaryOr => EntityConditionOperatorKindDto.LogicalNary,

            EntityConditionOperatorTypeInternal.LogicalUnaryNot => EntityConditionOperatorKindDto.LogicalUnary,

            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
