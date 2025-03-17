using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Abstractions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Date;

public sealed class EntityDateAttributeValueInternal
    : EntityAttributeValueGenericInternal<UtcDateTime<EntityDateAttributeValueInternal>>
{
    public EntityDateAttributeValueInternal(int id, UtcDateTime<EntityDateAttributeValueInternal>[] value) : base(id, value)
    {
    }
}
