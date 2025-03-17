using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Abstractions;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Number;

public sealed class EntityNumberAttributeValueInternal : EntityAttributeValueGenericInternal<long>
{
    public EntityNumberAttributeValueInternal(int id, long[] value) : base(id, value)
    {
    }
}
