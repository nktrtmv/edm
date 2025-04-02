using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;

public sealed class EntityNoneCondition : EntityCondition
{
    public static readonly EntityNoneCondition Instance = new EntityNoneCondition();

    private EntityNoneCondition()
    {
    }

    public override bool IsMet(Entity entity)
    {
        return true;
    }

    public override string ToDisplayText()
    {
        return string.Empty;
    }

    public override bool Equals(EntityCondition? other)
    {
        if (other is not EntityNoneCondition condition)
        {
            return false;
        }

        bool result = AreTypesEqual(other) && ReferenceEquals(this, condition);

        return result;
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
