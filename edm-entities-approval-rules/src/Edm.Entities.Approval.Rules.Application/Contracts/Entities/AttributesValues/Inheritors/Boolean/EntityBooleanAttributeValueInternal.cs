using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Abstractions;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Boolean;

public sealed class EntityBooleanAttributeValueInternal : EntityAttributeValueGenericInternal<bool>
{
    public EntityBooleanAttributeValueInternal(int id, bool[] value) : base(id, value)
    {
    }
}
