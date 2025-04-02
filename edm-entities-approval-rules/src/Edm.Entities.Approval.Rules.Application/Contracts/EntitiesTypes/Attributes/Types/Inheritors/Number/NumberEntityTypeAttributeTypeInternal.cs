namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Number;

public sealed class NumberEntityTypeAttributeTypeInternal : EntityTypeAttributeTypeInternal
{
    public NumberEntityTypeAttributeTypeInternal(int precision)
    {
        Precision = precision;
    }

    public int Precision { get; }
}
