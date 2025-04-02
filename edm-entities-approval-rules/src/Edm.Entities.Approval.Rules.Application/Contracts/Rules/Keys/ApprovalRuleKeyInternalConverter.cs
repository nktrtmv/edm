using Edm.Entities.Approval.Rules.Application.Contracts.EntitiesTypes.Keys;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.ValueObjects.Keys;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.EntitiesTypes.ValueObjects.Keys;

namespace Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;

internal static class ApprovalRuleKeyInternalConverter
{
    internal static ApprovalRuleKeyInternal FromDomain(ApprovalRule rule)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyInternalConverter.FromDomain(rule.EntityType.Key);

        var result = new ApprovalRuleKeyInternal(entityTypeKey, rule.Version);

        return result;
    }

    internal static ApprovalRuleKeyInternal FromDomain(ApprovalRuleKey key)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyInternalConverter.FromDomain(key.EntityTypeKey);

        var result = new ApprovalRuleKeyInternal(entityTypeKey, key.Version);

        return result;
    }

    internal static ApprovalRuleKey ToDomain(ApprovalRuleKeyInternal key)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyInternalConverter.ToDomain(key.EntityTypeKey);

        var result = new ApprovalRuleKey(entityTypeKey, key.Version);

        return result;
    }
}
