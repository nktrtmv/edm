using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators.Types;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries.Operators;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Unaries.Operators;

internal static class EntityConditionOperatorInternalConverter
{
    internal static EntityConditionOperatorDto ToDto(EntityConditionOperatorInternal @operator)
    {
        string displayName = @operator.DisplayName;

        EntityConditionOperatorDto result = @operator.Type switch
        {
            EntityConditionOperatorTypeInternal.LogicalUnaryNot =>
                ToDto(EntityConditionOperatorTypeDto.LogicalUnaryNot, displayName),

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        result.DisplayName = @operator.DisplayName;

        return result;
    }

    internal static EntityConditionOperatorInternal FromDto(EntityConditionOperatorDto @operator)
    {
        EntityConditionOperatorInternal result = @operator.Type switch
        {
            EntityConditionOperatorTypeDto.LogicalUnaryNot =>
                EntityLogicalUnaryConditionOperatorInternal.Not,

            _ => throw new ArgumentTypeOutOfRangeException(@operator)
        };

        return result;
    }

    private static EntityConditionOperatorDto ToDto(EntityConditionOperatorTypeDto type, string displayName)
    {
        var result = new EntityConditionOperatorDto
        {
            Kind = EntityConditionOperatorKindDto.LogicalUnary,
            Type = type,
            DisplayName = displayName
        };

        return result;
    }
}
