using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Abstractions;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.String;

public sealed class EntityStringAttributeValue : EntityAttributeValueGeneric<string>
{
    internal EntityStringAttributeValue(int id, string[] value) : base(id, value)
    {
    }
}
