using Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Abstractions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues.Inheritors.Reference;

public sealed class EntityReferenceAttributeValueInternal
    : EntityAttributeValueGenericInternal<Id<EntityReferenceAttributeValueInternal>>
{
    public EntityReferenceAttributeValueInternal(int id, Id<EntityReferenceAttributeValueInternal>[] value) : base(id, value)
    {
    }
}
