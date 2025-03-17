using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.AttributeValue;

internal static class EntityAttributeValueConditionBffConverter
{
    internal static EntityAttributeValueConditionBff FromDto(EntityAttributeValueConditionDto condition, ApprovalEnrichersContext context)
    {
        var @operator = EntityConditionOperatorBffConverter.FromDto(condition.Operator);

        var attributeValue = EntityAttributeValueBffConverter.FromDto(condition.AttributeValue, context);

        var result = new EntityAttributeValueConditionBff
        {
            Operator = @operator,
            AttributeValue = attributeValue
        };

        return result;
    }
}
