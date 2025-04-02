using Edm.Entities.Approval.Rules.Gateway.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;

internal static class EntityConditionOperatorKindBffConverter
{
    internal static EntityConditionOperatorKindBff FromDto(EntityConditionOperatorKindDto kind)
    {
        var result = kind switch
        {
            EntityConditionOperatorKindDto.AttributeValue => EntityConditionOperatorKindBff.AttributeValue,
            EntityConditionOperatorKindDto.LogicalNary => EntityConditionOperatorKindBff.LogicalNary,
            EntityConditionOperatorKindDto.LogicalUnary => EntityConditionOperatorKindBff.LogicalUnary,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }

    internal static EntityConditionOperatorKindDto ToDto(EntityConditionOperatorKindBff kind)
    {
        var result = kind switch
        {
            EntityConditionOperatorKindBff.AttributeValue => EntityConditionOperatorKindDto.AttributeValue,
            EntityConditionOperatorKindBff.LogicalNary => EntityConditionOperatorKindDto.LogicalNary,
            EntityConditionOperatorKindBff.LogicalUnary => EntityConditionOperatorKindDto.LogicalUnary,
            _ => throw new ArgumentTypeOutOfRangeException(kind)
        };

        return result;
    }
}
