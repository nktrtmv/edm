using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries.Operators;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions.Inheritors.Logical.Naries;

internal static class EntityLogicalNaryConditionInternalConverter
{
    internal static EntityLogicalNaryConditionDto ToDto(EntityLogicalNaryConditionInternal condition)
    {
        EntityConditionOperatorDto @operator =
            EntityConditionOperatorInternalConverter.ToDto(condition.Operator);

        EntityConditionDto[] innerConditions =
            condition.InnerConditions.Select(EntityConditionInternalConverter.ToDto).ToArray();

        var result = new EntityLogicalNaryConditionDto
        {
            Operator = @operator,
            InnerConditions = { innerConditions }
        };

        return result;
    }

    internal static EntityConditionInternal FromDto(EntityLogicalNaryConditionDto condition)
    {
        EntityConditionOperatorInternal @operator =
            EntityConditionOperatorInternalConverter.FromDto(condition.Operator);

        EntityConditionInternal[] innerConditions =
            condition.InnerConditions.Select(EntityConditionInternalConverter.FromDto).ToArray();

        return new EntityLogicalNaryConditionInternal(@operator, innerConditions);
    }
}
