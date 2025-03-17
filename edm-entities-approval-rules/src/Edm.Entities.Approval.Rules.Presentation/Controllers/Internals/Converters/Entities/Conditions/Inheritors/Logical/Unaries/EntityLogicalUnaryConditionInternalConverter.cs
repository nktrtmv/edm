using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Unaries.Operators;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Unaries;

internal static class EntityLogicalUnaryConditionInternalConverter
{
    internal static EntityLogicalUnaryConditionDto ToDto(EntityLogicalUnaryConditionInternal condition)
    {
        EntityConditionOperatorDto @operator =
            EntityConditionOperatorInternalConverter.ToDto(condition.Operator);

        EntityConditionDto innerCondition =
            EntityConditionInternalConverter.ToDto(condition.InnerCondition);

        var result = new EntityLogicalUnaryConditionDto
        {
            Operator = @operator,
            InnerCondition = innerCondition
        };

        return result;
    }

    internal static EntityConditionInternal FromDto(EntityLogicalUnaryConditionDto condition)
    {
        EntityConditionOperatorInternal @operator =
            EntityConditionOperatorInternalConverter.FromDto(condition.Operator);

        EntityConditionInternal innerCondition =
            EntityConditionInternalConverter.FromDto(condition.InnerCondition);

        return new EntityLogicalUnaryConditionInternal(@operator, innerCondition);
    }
}
