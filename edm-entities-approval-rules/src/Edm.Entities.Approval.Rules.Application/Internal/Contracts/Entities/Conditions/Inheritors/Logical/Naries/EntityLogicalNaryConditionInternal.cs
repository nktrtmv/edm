using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Naries;

public sealed class EntityLogicalNaryConditionInternal : EntityConditionInternal
{
    public EntityLogicalNaryConditionInternal(
        EntityConditionOperatorInternal @operator,
        EntityConditionInternal[] innerConditions)
    {
        Operator = @operator;
        InnerConditions = innerConditions;
    }

    public EntityConditionOperatorInternal Operator { get; }
    public EntityConditionInternal[] InnerConditions { get; }
}
