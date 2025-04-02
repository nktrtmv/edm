using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;

public sealed class ApprovalRuleKey
{
    public ApprovalRuleKey(EntityTypeKey entityTypeKey, int version)
    {
        EntityTypeKey = entityTypeKey;
        Version = version;
    }

    public EntityTypeKey EntityTypeKey { get; }
    public int Version { get; }

    public override string ToString()
    {
        return $"{{ EntityTypeKey: {EntityTypeKey}, Version: {Version} }}";
    }
}
