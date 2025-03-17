using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Attributes;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes;

public sealed class EntityType
{
    public EntityType(EntityTypeKey key, EntityTypeAttribute[] attributes, string displayName)
    {
        Key = key;
        Attributes = attributes;
        DisplayName = displayName;
    }

    public EntityTypeKey Key { get; }
    public EntityTypeAttribute[] Attributes { get; }
    public string DisplayName { get; }

    public override string ToString()
    {
        string attributes = string.Join<EntityTypeAttribute>(", ", Attributes);

        return $"{{ Key: {Key}, DisplayName: {DisplayName}, Attributes: [{attributes}] }}";
    }
}
