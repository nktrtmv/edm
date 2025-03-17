using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Attributes;
using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Application.External.Rules.Commands.UpsertEntityType.Contracts.EntitiesTypes;

public sealed class EntityTypeInternal
{
    public EntityTypeInternal(EntityTypeKeyInternal typeKey, EntityTypeAttributeInternal[] attributes, string displayName)
    {
        TypeKey = typeKey;
        Attributes = attributes;
        DisplayName = displayName;
    }

    public EntityTypeKeyInternal TypeKey { get; }
    public EntityTypeAttributeInternal[] Attributes { get; }
    public string DisplayName { get; }
}
