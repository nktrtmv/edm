using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.ApprovalRulesKeys.EntitiesTypes.Keys;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys.EntitiesTypes.Keys;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.ApprovalRulesKeys;

internal static class ExternalApprovalRuleKeyDtoConverter
{
    internal static ApprovalRuleKeyInternal ToInternal(ApprovalRuleKeyDto approvalRuleKey)
    {
        EntityTypeKeyInternal entityTypekey = ExternalEntityTypeKeyDtoConverter.ToInternal(approvalRuleKey.EntityTypeKey);

        var result = new ApprovalRuleKeyInternal(entityTypekey, approvalRuleKey.Version);

        return result;
    }
}
