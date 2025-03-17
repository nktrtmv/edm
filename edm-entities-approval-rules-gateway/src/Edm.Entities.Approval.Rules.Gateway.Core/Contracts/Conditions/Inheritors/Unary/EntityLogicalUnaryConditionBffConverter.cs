using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Unary;

internal static class EntityLogicalUnaryConditionBffConverter
{
    internal static EntityLogicalUnaryConditionBff FromDto(EntityLogicalUnaryConditionDto condition, ApprovalEnrichersContext context)
    {
        var @operator = EntityConditionOperatorBffConverter.FromDto(condition.Operator);

        var innerCondition = EntityConditionBffConverter.FromDto(condition.InnerCondition, context);

        var result = new EntityLogicalUnaryConditionBff
        {
            Operator = @operator,
            InnerCondition = innerCondition
        };

        return result;
    }

    internal static EntityLogicalUnaryConditionDto ToDto(EntityLogicalUnaryConditionBff condition)
    {
        var @operator = EntityConditionOperatorBffConverter.ToDto(condition.Operator);

        var innerCondition = EntityConditionBffConverter.ToDto(condition.InnerCondition);

        var result = new EntityLogicalUnaryConditionDto
        {
            Operator = @operator,
            InnerCondition = innerCondition
        };

        return result;
    }
}
