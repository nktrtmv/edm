namespace Edm.Entities.Approval.Rules.Application.Contracts.Entities.AttributesValues;

public abstract class EntityAttributeValueInternal
{
    protected EntityAttributeValueInternal(int id)
    {
        Id = id;
    }

    public int Id { get; }
}
