using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries.Operators;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators.Kinds;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators.Types;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators;

internal static class EntityConditionOperatorInternalConverter
{
    internal static EntityConditionOperatorDto ToDto(EntityConditionOperatorInternal @operator)
    {
        EntityConditionOperatorKindDto kind = EntityConditionOperatorKindDtoConverter.FromInternal(@operator.Type);

        EntityConditionOperatorTypeDto type = EntityConditionOperatorTypeInternalConverter.ToDto(@operator.Type);

        var result = new EntityConditionOperatorDto
        {
            Kind = kind,
            Type = type,
            DisplayName = @operator.DisplayName
        };

        return result;
    }

    internal static EntityConditionOperatorInternal FromDto(EntityConditionOperatorDto @operator)
    {
        EntityConditionOperatorInternal result = @operator.Type switch
        {
            EntityConditionOperatorTypeDto.AttributeValueEqual => EntityAttributeValueConditionOperatorInternal.Equal,
            EntityConditionOperatorTypeDto.AttributeValueGreater => EntityAttributeValueConditionOperatorInternal.Greater,
            EntityConditionOperatorTypeDto.AttributeValueGreaterOrEqual => EntityAttributeValueConditionOperatorInternal.GreaterOrEqual,
            EntityConditionOperatorTypeDto.AttributeValueLess => EntityAttributeValueConditionOperatorInternal.Less,
            EntityConditionOperatorTypeDto.AttributeValueLessOrEqual => EntityAttributeValueConditionOperatorInternal.LessOrEqual,

            EntityConditionOperatorTypeDto.LogicalNaryAnd => EntityLogicalNaryConditionOperatorInternal.And,
            EntityConditionOperatorTypeDto.LogicalNaryOr => EntityLogicalNaryConditionOperatorInternal.Or,

            EntityConditionOperatorTypeDto.LogicalUnaryNot => EntityLogicalUnaryConditionOperatorInternal.Not,

            _ => throw new ArgumentTypeOutOfRangeException(@operator.Type)
        };

        return result;
    }
}
