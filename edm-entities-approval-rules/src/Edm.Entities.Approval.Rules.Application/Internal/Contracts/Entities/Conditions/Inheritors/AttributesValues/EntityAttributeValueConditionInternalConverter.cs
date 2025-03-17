using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.AttributesValues;

internal static class EntityAttributeValueConditionInternalConverter
{
    internal static EntityAttributeValueConditionInternal FromDomain(EntityAttributeValueCondition condition)
    {
        EntityConditionOperatorInternal @operator =
            EntityConditionOperatorInternalConverter.FromDomain(condition.Operator);

        EntityAttributeValueInternal attributeValue =
            EntityAttributeValueInternalFromDomainConverter.FromDomain(condition.AttributeValue);

        var result = new EntityAttributeValueConditionInternal(@operator, attributeValue);

        return result;
    }

    internal static EntityAttributeValueCondition ToDomain(EntityAttributeValueConditionInternal condition)
    {
        EntityAttributeValueConditionOperator @operator =
            EntityAttributeValueConditionOperatorInternalConverter.ToDomain(condition.Operator);

        EntityAttributeValue attributeValue =
            EntityAttributeValueInternalToDomainConverter.ToDomain(condition.AttributeValue);

        var result = new EntityAttributeValueCondition(@operator, attributeValue);

        return result;
    }
}
