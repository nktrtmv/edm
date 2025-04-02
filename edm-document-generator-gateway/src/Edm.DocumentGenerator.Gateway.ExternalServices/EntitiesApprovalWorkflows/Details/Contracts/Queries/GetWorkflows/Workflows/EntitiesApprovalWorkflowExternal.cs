using Edm.DocumentGenerator.Gateway.ExternalServices.Contracts.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Statuses;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

public sealed class EntitiesApprovalWorkflowExternal
{
    public EntitiesApprovalWorkflowExternal(
        string id,
        EntitiesApprovalWorkflowStageExternal[] stages,
        string[] ownersIds,
        ApprovalRuleKeyExternal? approvalRuleKey,
        DateTime? routeUpdatedDate,
        ApprovalWorkflowStatusExternal status)
    {
        Id = id;
        Stages = stages;
        OwnersIds = ownersIds;
        ApprovalRuleKey = approvalRuleKey;
        RouteUpdatedDate = routeUpdatedDate;
        Status = status;
    }

    public string Id { get; }
    public EntitiesApprovalWorkflowStageExternal[] Stages { get; }
    public string[] OwnersIds { get; }
    public ApprovalRuleKeyExternal? ApprovalRuleKey { get; }
    public DateTime? RouteUpdatedDate { get; }
    public ApprovalWorkflowStatusExternal Status { get; }
}
