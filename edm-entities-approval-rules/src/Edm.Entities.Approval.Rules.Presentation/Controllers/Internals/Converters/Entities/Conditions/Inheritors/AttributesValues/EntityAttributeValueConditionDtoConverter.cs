using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Presentation.Abstractions;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.Presentation.Converters.Entities.AttributesValues;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.AttributesValues;

internal static class EntityAttributeValueConditionDtoConverter
{
    internal static EntityAttributeValueConditionDto ToDto(EntityAttributeValueConditionInternal condition)
    {
        EntityConditionOperatorDto @operator =
            EntityConditionOperatorInternalConverter.ToDto(condition.Operator);

        EntityAttributeValueDto attributeValue =
            EntityAttributeValueInternalToDtoConverter.ToDto(condition.AttributeValue);

        return new EntityAttributeValueConditionDto
        {
            Operator = @operator,
            AttributeValue = attributeValue
        };
    }

    internal static EntityConditionInternal FromDto(EntityAttributeValueConditionDto condition)
    {
        EntityConditionOperatorInternal @operator =
            EntityConditionOperatorInternalConverter.FromDto(condition.Operator);

        EntityAttributeValueInternal attributeValue =
            EntityAttributeValueInternalFromDtoConverter.FromDto(condition.AttributeValue);

        return new EntityAttributeValueConditionInternal(@operator, attributeValue);
    }
}
