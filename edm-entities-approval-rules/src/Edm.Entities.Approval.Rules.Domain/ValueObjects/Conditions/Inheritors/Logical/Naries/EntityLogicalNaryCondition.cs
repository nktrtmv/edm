using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries.ValueObjects.Operators;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Logical.Naries;

public sealed class EntityLogicalNaryCondition : EntityCondition
{
    public EntityLogicalNaryCondition(EntityLogicalNaryConditionOperator @operator, EntityCondition[] innerConditions)
    {
        Operator = @operator;
        InnerConditions = innerConditions;
    }

    public EntityLogicalNaryConditionOperator Operator { get; }
    public EntityCondition[] InnerConditions { get; }

    public override bool IsMet(Entity entity)
    {
        bool result = Operator.IsMet(InnerConditions, entity);

        return result;
    }

    public override string ToDisplayText()
    {
        string innerConditionsDisplayText = string.Join(", ", InnerConditions.Select(x => x.ToString()));

        var result = $"{Operator.DisplayName} ({innerConditionsDisplayText})";

        return result;
    }

    public override bool Equals(EntityCondition? other)
    {
        if (other is not EntityLogicalNaryCondition condition)
        {
            return false;
        }

        bool result = AreTypesEqual(other) && AreConditionsEqual(condition);

        return result;
    }

    private bool AreConditionsEqual(EntityLogicalNaryCondition condition)
    {
        bool areOperatorsEqual = EqualityComparer<EntityLogicalNaryConditionOperator>.Default.Equals(Operator, condition.Operator);
        bool areInnerConditionsEqual = InnerConditions.SequenceEqual(condition.InnerConditions);

        bool result = areOperatorsEqual && areInnerConditionsEqual;

        return result;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Operator, InnerConditions);
    }

    public override string ToString()
    {
        string innerConditions = string.Join<EntityCondition>(", ", InnerConditions);

        return $"{{ {BaseToString()}, Operator: {Operator}, InnerConditions: [{innerConditions}] }}";
    }
}
