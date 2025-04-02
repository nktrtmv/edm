using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Reference;

public sealed class ReferenceEntityTypeAttributeTypeInternal : EntityTypeAttributeTypeInternal
{
    public ReferenceEntityTypeAttributeTypeInternal(Id<EntityTypeReferenceAttributeInternal> referenceTypeId)
    {
        ReferenceTypeId = referenceTypeId;
    }

    public Id<EntityTypeReferenceAttributeInternal> ReferenceTypeId { get; }
}
