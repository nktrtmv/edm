using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

public sealed class ApprovalRuleKeyInternal
{
    public ApprovalRuleKeyInternal(EntityTypeKeyInternal entityTypeKey, int version)
    {
        EntityTypeKey = entityTypeKey;
        Version = version;
    }

    public EntityTypeKeyInternal EntityTypeKey { get; }
    public int Version { get; }
}
