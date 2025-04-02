using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Abstractions;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.String;

public sealed class EntityStringAttributeValueInternal : EntityAttributeValueGenericInternal<string>
{
    public EntityStringAttributeValueInternal(int id, string[] value) : base(id, value)
    {
    }
}
