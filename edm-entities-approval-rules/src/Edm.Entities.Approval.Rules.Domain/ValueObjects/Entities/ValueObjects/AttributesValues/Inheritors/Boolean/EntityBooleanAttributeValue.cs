using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Abstractions;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Boolean;

public sealed class EntityBooleanAttributeValue : EntityAttributeValueGeneric<bool>
{
    internal EntityBooleanAttributeValue(int id, bool[] value) : base(id, value)
    {
    }

    public override int CompareTo(EntityAttributeValue? other)
    {
        throw new ArgumentException($"The Greater/Less operation is not supported by reference attribute value (id:{Id}, type:{GetType()}).");
    }
}
