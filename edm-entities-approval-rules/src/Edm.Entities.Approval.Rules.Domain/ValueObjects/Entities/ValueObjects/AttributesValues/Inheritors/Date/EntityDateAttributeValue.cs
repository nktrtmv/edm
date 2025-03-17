using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Abstractions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Date;

public sealed class EntityDateAttributeValue : EntityAttributeValueGeneric<UtcDateTime<EntityDateAttributeValue>>
{
    internal EntityDateAttributeValue(int id, UtcDateTime<EntityDateAttributeValue>[] value) : base(id, value)
    {
    }
}
