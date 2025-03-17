using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Abstractions;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Number;

public sealed class EntityNumberAttributeValue : EntityAttributeValueGeneric<long>
{
    internal EntityNumberAttributeValue(int id, long[] value) : base(id, value)
    {
    }
}
