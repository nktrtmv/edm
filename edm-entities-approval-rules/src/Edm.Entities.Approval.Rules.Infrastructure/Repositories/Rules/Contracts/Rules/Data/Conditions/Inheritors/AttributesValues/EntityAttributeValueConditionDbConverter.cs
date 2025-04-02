using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.AttributesValues.Operators;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Entities.AttributesValues;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions.Inheritors.AttributesValues;

internal static class EntityAttributeValueConditionDbConverter
{
    internal static EntityAttributeValueCondition ToDomain(EntityAttributeValueConditionDb condition)
    {
        EntityAttributeValueConditionOperator @operator =
            EntityAttributeValueConditionOperatorDbConverter.ToDomain(condition.Operator);

        EntityAttributeValue attributeValue =
            EntityAttributeValueDbToDomainConverter.ToDomain(condition.AttributeValue);

        var result = new EntityAttributeValueCondition(@operator, attributeValue);

        return result;
    }

    internal static EntityAttributeValueConditionDb FromDomain(EntityAttributeValueCondition condition)
    {
        EntityConditionOperatorTypeDb @operator =
            EntityAttributeValueConditionOperatorDbConverter.FromDomain(condition.Operator);

        EntityAttributeValueDb attributeValue =
            EntityAttributeValueDbFromDomainConverter.FromDomain(condition.AttributeValue);

        return new EntityAttributeValueConditionDb
        {
            Operator = @operator,
            AttributeValue = attributeValue
        };
    }
}
