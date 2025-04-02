using Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys.EntitiesTypesKeys;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys;

public sealed class ApprovalRuleKeyExternal
{
    public ApprovalRuleKeyExternal(EntityTypeKeyExternal entityTypeKey, int version)
    {
        EntityTypeKey = entityTypeKey;
        Version = version;
    }

    public EntityTypeKeyExternal EntityTypeKey { get; }
    public int Version { get; }
}
