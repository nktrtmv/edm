namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Number;

public sealed class NumberEntityTypeAttributeType : EntityTypeAttributeType
{
    public NumberEntityTypeAttributeType(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
