namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Boolean;

public sealed class BooleanEntityTypeAttributeTypeInternal : EntityTypeAttributeTypeInternal
{
    private BooleanEntityTypeAttributeTypeInternal()
    {
    }

    public static BooleanEntityTypeAttributeTypeInternal Instance { get; } = new BooleanEntityTypeAttributeTypeInternal();
}
