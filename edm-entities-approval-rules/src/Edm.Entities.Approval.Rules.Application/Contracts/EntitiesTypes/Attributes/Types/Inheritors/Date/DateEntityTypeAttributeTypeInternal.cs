namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Types.Inheritors.Date;

public sealed class DateEntityTypeAttributeTypeInternal : EntityTypeAttributeTypeInternal
{
    private DateEntityTypeAttributeTypeInternal()
    {
    }

    public static DateEntityTypeAttributeTypeInternal Instance { get; } = new DateEntityTypeAttributeTypeInternal();
}
