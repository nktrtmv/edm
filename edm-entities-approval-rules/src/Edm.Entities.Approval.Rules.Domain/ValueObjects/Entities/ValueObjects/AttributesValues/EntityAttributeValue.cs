namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

public abstract class EntityAttributeValue(int id) : IComparable<EntityAttributeValue>,
    IEquatable<EntityAttributeValue>

{
    //TODO Только для миграции маршрута согласования. Убрать protected set;
    public int Id { get; protected set; } = id;

    public abstract int CompareTo(EntityAttributeValue? other);

    public abstract bool Equals(EntityAttributeValue? other);
}
