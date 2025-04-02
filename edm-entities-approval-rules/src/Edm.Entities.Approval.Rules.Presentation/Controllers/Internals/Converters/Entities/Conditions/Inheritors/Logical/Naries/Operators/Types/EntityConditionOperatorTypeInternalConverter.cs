using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators.Types;

internal static class EntityConditionOperatorTypeInternalConverter
{
    internal static EntityConditionOperatorTypeDto ToDto(EntityConditionOperatorTypeInternal type)
    {
        EntityConditionOperatorTypeDto result = type switch
        {
            EntityConditionOperatorTypeInternal.AttributeValueEqual => EntityConditionOperatorTypeDto.AttributeValueEqual,
            EntityConditionOperatorTypeInternal.AttributeValueGreater => EntityConditionOperatorTypeDto.AttributeValueGreater,
            EntityConditionOperatorTypeInternal.AttributeValueGreaterOrEqual => EntityConditionOperatorTypeDto.AttributeValueGreaterOrEqual,
            EntityConditionOperatorTypeInternal.AttributeValueLess => EntityConditionOperatorTypeDto.AttributeValueLess,
            EntityConditionOperatorTypeInternal.AttributeValueLessOrEqual => EntityConditionOperatorTypeDto.AttributeValueLessOrEqual,

            EntityConditionOperatorTypeInternal.LogicalNaryAnd => EntityConditionOperatorTypeDto.LogicalNaryAnd,
            EntityConditionOperatorTypeInternal.LogicalNaryOr => EntityConditionOperatorTypeDto.LogicalNaryOr,

            EntityConditionOperatorTypeInternal.LogicalUnaryNot => EntityConditionOperatorTypeDto.LogicalUnaryNot,

            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
