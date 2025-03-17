using Edm.Entities.Approval.Rules.GenericSubdomain.Extensions.Arrays.Comparers;
using Edm.Entities.Approval.Rules.GenericSubdomain.Extensions.Types;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Abstractions;

public abstract class EntityAttributeValueGeneric<T> : EntityAttributeValue where T : IComparable<T>, IEquatable<T>
{
    protected EntityAttributeValueGeneric(int id, T[] value) : base(id)
    {
        Value = value;
    }

    public T[] Value { get; protected set; }

    public override int CompareTo(EntityAttributeValue? other)
    {
        EntityAttributeValueGeneric<T> otherAttributeValue = TypeCasterTo<EntityAttributeValueGeneric<T>>.CastRequired(other);

        if (Value.Length != otherAttributeValue.Value.Length)
        {
            return -1;
        }

        if (Value.Length == 0)
        {
            return 0;
        }

        if (Value.Length != 1)
        {
            throw new ApplicationException(
                $$"""
                  Compared attribute values must have exactly one value.
                  CurrentAttributeValue: { Id: {{Id}}, Length: {{Value.Length}} }
                  OtherAttributeValue: { Id: {{otherAttributeValue.Id}}, Length: {{otherAttributeValue.Value.Length}} }
                  """);
        }

        int result = Comparer<T>.Default.Compare(Value.Single(), otherAttributeValue.Value.Single());

        return result;
    }

    public override bool Equals(EntityAttributeValue? other)
    {
        EntityAttributeValueGeneric<T> otherAttributeValue = TypeCasterTo<EntityAttributeValueGeneric<T>>.CastRequired(other);

        bool result = ArrayComparer.Equals(Value, otherAttributeValue.Value);

        return result;
    }
}
