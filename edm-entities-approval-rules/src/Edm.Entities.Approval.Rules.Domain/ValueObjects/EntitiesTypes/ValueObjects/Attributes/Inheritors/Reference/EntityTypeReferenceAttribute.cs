using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Reference;

public sealed class EntityTypeReferenceAttribute : EntityTypeAttribute
{
    internal EntityTypeReferenceAttribute(EntityTypeAttributeData data, Metadata<EntityTypeReferenceAttribute> referenceTypeId) : base(data)
    {
        ReferenceTypeId = referenceTypeId;
    }

    //TODO Только для миграции маршрута согласования. Убрать set;
    public Metadata<EntityTypeReferenceAttribute> ReferenceTypeId { get; set; }
}
