using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Converters.ApprovalRulesKeys.EntitiesTypes.Keys;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Workflows.Presentation.Converters.ApprovalRulesKeys;

internal static class ApprovalRuleKeyDtoConverter
{
    internal static ApprovalRuleKeyInternal ToInternal(ApprovalRuleKeyDto approvalRuleKey)
    {
        EntityTypeKeyInternal entityTypekey = EntityTypeKeyDtoConverter.ToInternal(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyInternal(entityTypekey, approvalRuleKey.Version);

        return result;
    }

    internal static ApprovalRuleKeyDto FromInternal(ApprovalRuleKeyInternal approvalRuleKey)
    {
        EntityTypeKeyDto entityTypekey = EntityTypeKeyDtoConverter.FromInternal(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyDto
        {
            EntityTypeKey = entityTypekey,
            Version = approvalRuleKey.Version
        };

        return result;
    }
}
