using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;

public abstract class EntityCondition : IEquatable<EntityCondition>
{
    public abstract bool Equals(EntityCondition? other);

    public abstract bool IsMet(Entity entity);

    public abstract string ToDisplayText();

    public override bool Equals(object? obj)
    {
        return Equals(obj as EntityCondition);
    }

    public abstract override int GetHashCode();

    protected bool AreTypesEqual(EntityCondition otherCondition)
    {
        return GetType() == otherCondition.GetType();
    }

    protected string BaseToString()
    {
        return $"Type: {GetType().Name}";
    }

    public override string ToString()
    {
        return $"{{ {BaseToString()} }}";
    }
}
