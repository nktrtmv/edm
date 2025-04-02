using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys.Entities.Types.Keys;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ApprovalRulesKeys.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.ApprovalRulesKeys;

internal static class ApprovalRuleKeyDbConverter
{
    internal static ApprovalRuleKey ToDomain(ApprovalRuleKeyDb approvalRuleKey)
    {
        EntityTypeKey entityTypekey = EntityTypeKeyDbConverter.ToDomain(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKey(entityTypekey, approvalRuleKey.Version);

        return result;
    }

    internal static ApprovalRuleKeyDb FromDomain(ApprovalRuleKey approvalRuleKey)
    {
        EntityTypeKeyDb entityTypekey = EntityTypeKeyDbConverter.FromDomain(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyDb
        {
            EntityTypeKey = entityTypekey,
            Version = approvalRuleKey.Version
        };

        return result;
    }
}
