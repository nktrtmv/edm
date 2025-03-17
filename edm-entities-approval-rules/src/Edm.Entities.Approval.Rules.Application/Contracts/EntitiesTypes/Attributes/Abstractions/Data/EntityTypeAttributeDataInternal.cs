namespace Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes.Abstractions.Data;

public sealed class EntityTypeAttributeDataInternal
{
    public EntityTypeAttributeDataInternal(int id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }

    public int Id { get; }
    public string DisplayName { get; }
}
