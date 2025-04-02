namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Types.Inheritors.Date;

public sealed class DateEntityTypeAttributeType : EntityTypeAttributeType
{
    private DateEntityTypeAttributeType()
    {
    }

    public static DateEntityTypeAttributeType Instance { get; } = new DateEntityTypeAttributeType();
}
