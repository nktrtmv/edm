using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;

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
