using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions.Inheritors.Nary;

internal static class EntityLogicalNaryConditionBffConverter
{
    internal static EntityLogicalNaryConditionBff FromDto(EntityLogicalNaryConditionDto condition, ApprovalEnrichersContext context)
    {
        var @operator =
            EntityConditionOperatorBffConverter.FromDto(condition.Operator);

        EntityConditionBff[] innerConditions =
            condition.InnerConditions.Select(c => EntityConditionBffConverter.FromDto(c, context)).ToArray();

        var result = new EntityLogicalNaryConditionBff
        {
            Operator = @operator,
            InnerConditions = innerConditions
        };

        return result;
    }

    internal static EntityLogicalNaryConditionDto ToDto(EntityLogicalNaryConditionBff condition)
    {
        var @operator =
            EntityConditionOperatorBffConverter.ToDto(condition.Operator);

        EntityConditionDto[] innerConditions =
            condition.InnerConditions.Select(EntityConditionBffConverter.ToDto).ToArray();

        var result = new EntityLogicalNaryConditionDto
        {
            Operator = @operator,
            InnerConditions = { innerConditions }
        };

        return result;
    }
}
