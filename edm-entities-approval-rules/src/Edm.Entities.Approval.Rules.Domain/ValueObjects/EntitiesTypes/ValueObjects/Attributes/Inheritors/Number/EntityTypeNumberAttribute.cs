using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.Inheritors.Number;

public sealed class EntityTypeNumberAttribute : EntityTypeAttribute
{
    internal EntityTypeNumberAttribute(EntityTypeAttributeData data, int precision) : base(data)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
