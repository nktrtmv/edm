using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Abstractions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues.Inheritors.Reference;

public sealed class EntityReferenceAttributeValue : EntityAttributeValueGeneric<Id<EntityReferenceAttributeValue>>
{
    internal EntityReferenceAttributeValue(int id, Id<EntityReferenceAttributeValue>[] value) : base(id, value)
    {
    }

    public override int CompareTo(EntityAttributeValue? other)
    {
        throw new ArgumentException($"The Greater/Less operation is not supported by reference attribute value (id:{Id}, type:{GetType()}).");
    }

    internal void SetValue(Id<EntityReferenceAttributeValue>[] value)
    {
        Value = value;
    }

    //TODO Только для миграции маршрута согласования. Убрать SetId
    public void SetId(int id)
    {
        Id = id;
    }
}
