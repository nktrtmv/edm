using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Unaries;

public sealed class EntityLogicalUnaryCondition : EntityCondition
{
    public EntityLogicalUnaryCondition(EntityLogicalUnaryConditionOperator @operator, EntityCondition innerCondition)
    {
        Operator = @operator;
        InnerCondition = innerCondition;
    }

    public EntityLogicalUnaryConditionOperator Operator { get; }
    public EntityCondition InnerCondition { get; }

    public override bool IsMet(Entity entity)
    {
        bool result = Operator.IsMet(InnerCondition, entity);

        return result;
    }

    public override string ToDisplayText()
    {
        var result = $"{Operator.DisplayName} {InnerCondition.ToDisplayText()}";

        return result;
    }

    public override bool Equals(EntityCondition? other)
    {
        if (other is not EntityLogicalUnaryCondition condition)
        {
            return false;
        }

        bool result = AreTypesEqual(other) && AreConditionsEqual(condition);

        return result;
    }

    private bool AreConditionsEqual(EntityLogicalUnaryCondition condition)
    {
        bool areOperatorsEqual = EqualityComparer<EntityLogicalUnaryConditionOperator>.Default.Equals(Operator, condition.Operator);
        bool areInnerConditionsEqual = EqualityComparer<EntityCondition>.Default.Equals(InnerCondition, condition.InnerCondition);

        bool result = areOperatorsEqual && areInnerConditionsEqual;

        return result;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Operator, InnerCondition);
    }

    public override string ToString()
    {
        return $"{{ {BaseToString()}, Operator: {Operator}, InnerCondition: [{InnerCondition}] }}";
    }
}
