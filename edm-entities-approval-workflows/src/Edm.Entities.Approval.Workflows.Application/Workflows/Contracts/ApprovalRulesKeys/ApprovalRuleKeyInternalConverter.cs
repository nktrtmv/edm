using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;

internal static class ApprovalRuleKeyInternalConverter
{
    internal static ApprovalRuleKey ToDomain(ApprovalRuleKeyInternal approvalRuleKey)
    {
        EntityTypeKey entityTypeKey = EntityTypeKeyInternalConverter.ToDomain(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKey(entityTypeKey, approvalRuleKey.Version);

        return result;
    }

    internal static ApprovalRuleKeyInternal FromDomain(ApprovalRuleKey approvalRuleKey)
    {
        EntityTypeKeyInternal entityTypeKey = EntityTypeKeyInternalConverter.FromDomain(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyInternal(entityTypeKey, approvalRuleKey.Version);

        return result;
    }
}
