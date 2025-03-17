using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Reference;

public sealed class ReferenceEntityTypeAttributeType : EntityTypeAttributeType
{
    public ReferenceEntityTypeAttributeType(Id<EntityTypeReferenceAttribute> referenceTypeId)
    {
        ReferenceTypeId = referenceTypeId;
    }

    public Id<EntityTypeReferenceAttribute> ReferenceTypeId { get; }
}
