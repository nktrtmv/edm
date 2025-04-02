using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;

namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Inheritors.Number;

public sealed class EntityTypeNumberAttributeInternal : EntityTypeAttributeInternal
{
    public EntityTypeNumberAttributeInternal(EntityTypeAttributeDataInternal data, int precision) : base(data)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
