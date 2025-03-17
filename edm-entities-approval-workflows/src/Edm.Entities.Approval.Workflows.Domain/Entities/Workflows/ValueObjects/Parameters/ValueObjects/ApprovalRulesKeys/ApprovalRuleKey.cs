using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;

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
