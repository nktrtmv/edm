using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes.ValueObjects.Data;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;

public abstract class EntityTypeAttribute
{
    protected EntityTypeAttribute(EntityTypeAttributeData data)
    {
        Data = data;
    }

    public EntityTypeAttributeData Data { get; }

    public int Id => Data.Id;
    public string DisplayName => Data.DisplayName;

    public override string ToString()
    {
        return $"{{ Id: {Id}, DisplayName: {DisplayName}, Type: {GetType().Name} }}";
    }
}
