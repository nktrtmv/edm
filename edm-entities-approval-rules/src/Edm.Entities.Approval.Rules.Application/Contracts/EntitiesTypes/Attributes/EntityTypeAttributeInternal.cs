using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;

public abstract class EntityTypeAttributeInternal(EntityTypeAttributeDataInternal data)
{
    public EntityTypeAttributeDataInternal Data { get; } = data;
}
