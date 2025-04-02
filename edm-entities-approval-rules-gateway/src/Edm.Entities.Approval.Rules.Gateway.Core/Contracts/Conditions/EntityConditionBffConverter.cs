using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.AttributeValue;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Nary;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.None;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Unary;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Entities.AttributeValues;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;

internal static class EntityConditionBffConverter
{
    internal static EntityConditionBff FromDto(EntityConditionDto condition, ApprovalEnrichersContext context)
    {
        EntityConditionBff result = condition.ValueCase switch
        {
            EntityConditionDto.ValueOneofCase.AsAttributeValue => EntityAttributeValueConditionBffConverter.FromDto(condition.AsAttributeValue, context),
            EntityConditionDto.ValueOneofCase.AsLogicalNary => EntityLogicalNaryConditionBffConverter.FromDto(condition.AsLogicalNary, context),
            EntityConditionDto.ValueOneofCase.AsLogicalUnary => EntityLogicalUnaryConditionBffConverter.FromDto(condition.AsLogicalUnary, context),
            EntityConditionDto.ValueOneofCase.AsNone => EntityNoneConditionBffConverter.FromDto(),
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    internal static EntityConditionDto ToDto(EntityConditionBff condition)
    {
        var result = condition switch
        {
            EntityLogicalNaryConditionBff c => new EntityConditionDto
            {
                AsLogicalNary = EntityLogicalNaryConditionBffConverter.ToDto(c)
            },
            EntityNoneConditionBff => new EntityConditionDto
            {
                AsNone = EntityNoneConditionBffConverter.ToDto()
            },
            EntityAttributeValueConditionBff c => new EntityConditionDto
            {
                AsAttributeValue = ToAttributeValue(c)
            },
            EntityLogicalUnaryConditionBff c => new EntityConditionDto
            {
                AsLogicalUnary = EntityLogicalUnaryConditionBffConverter.ToDto(c)
            },
            _ => throw new ArgumentTypeOutOfRangeException(condition)
        };

        return result;
    }

    private static EntityAttributeValueConditionDto ToAttributeValue(EntityAttributeValueConditionBff condition)
    {
        var result = new EntityAttributeValueConditionDto
        {
            Operator = EntityConditionOperatorBffConverter.ToDto(condition.Operator),
            AttributeValue = EntityAttributeValueBffConverter.ToDto(condition.AttributeValue)
        };

        return result;
    }
}
