using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;

public sealed class EntityTypeReferenceAttributeInternal : EntityTypeAttributeInternal
{
    public EntityTypeReferenceAttributeInternal(
        EntityTypeAttributeDataInternal data,
        Metadata<EntityTypeReferenceAttributeInternal> referenceTypeId) : base(data)
    {
        ReferenceTypeId = referenceTypeId;
    }

    public Metadata<EntityTypeReferenceAttributeInternal> ReferenceTypeId { get; }
}
