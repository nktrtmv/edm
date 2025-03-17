using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Entities;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Info;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.Factories;

public static class ApprovalWorkflowParametersFactory
{
    public static ApprovalWorkflowParameters CreateFrom(
        ApprovalWorkflowEntity entity,
        ApprovalWorkflowInfo info,
        ApprovalWorkflowOptions options,
        ApprovalRuleKey? approvalRuleKey,
        UtcDateTime<ApprovalRoute>? routeUpdatedDate)
    {
        ApprovalWorkflowParameters result = CreateFromDb(entity, info, options, approvalRuleKey, routeUpdatedDate);

        return result;
    }

    public static ApprovalWorkflowParameters CreateFromDb(
        ApprovalWorkflowEntity entity,
        ApprovalWorkflowInfo info,
        ApprovalWorkflowOptions options,
        ApprovalRuleKey? approvalRuleKey,
        UtcDateTime<ApprovalRoute>? routeUpdatedDate)
    {
        var result = new ApprovalWorkflowParameters(entity, info, options, approvalRuleKey, routeUpdatedDate);

        return result;
    }
}
