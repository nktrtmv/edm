namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.String;

public sealed class StringEntityTypeAttributeTypeInternal : EntityTypeAttributeTypeInternal
{
    private StringEntityTypeAttributeTypeInternal()
    {
    }

    public static StringEntityTypeAttributeTypeInternal Instance { get; } = new StringEntityTypeAttributeTypeInternal();
}
