namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Boolean;

public sealed class BooleanEntityTypeAttributeType : EntityTypeAttributeType
{
    private BooleanEntityTypeAttributeType()
    {
    }

    public static BooleanEntityTypeAttributeType Instance { get; } = new BooleanEntityTypeAttributeType();
}
