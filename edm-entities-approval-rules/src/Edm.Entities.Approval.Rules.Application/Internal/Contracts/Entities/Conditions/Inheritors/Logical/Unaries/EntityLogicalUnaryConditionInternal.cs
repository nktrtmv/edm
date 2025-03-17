using Edm.Entities.Approval.Rules.Application.Contracts.Conditions.Operators;

namespace Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions.Inheritors.Logical.Unaries;

public sealed class EntityLogicalUnaryConditionInternal : EntityConditionInternal
{
    public EntityLogicalUnaryConditionInternal(EntityConditionOperatorInternal @operator, EntityConditionInternal innerCondition)
    {
        Operator = @operator;
        InnerCondition = innerCondition;
    }

    public EntityConditionOperatorInternal Operator { get; }
    public EntityConditionInternal InnerCondition { get; }
}
