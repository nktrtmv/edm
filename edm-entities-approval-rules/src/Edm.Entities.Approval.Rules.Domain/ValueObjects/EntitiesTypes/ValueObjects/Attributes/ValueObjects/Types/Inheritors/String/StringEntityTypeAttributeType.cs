namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.String;

public sealed class StringEntityTypeAttributeType : EntityTypeAttributeType
{
    private StringEntityTypeAttributeType()
    {
    }

    public static StringEntityTypeAttributeType Instance { get; } = new StringEntityTypeAttributeType();
}
