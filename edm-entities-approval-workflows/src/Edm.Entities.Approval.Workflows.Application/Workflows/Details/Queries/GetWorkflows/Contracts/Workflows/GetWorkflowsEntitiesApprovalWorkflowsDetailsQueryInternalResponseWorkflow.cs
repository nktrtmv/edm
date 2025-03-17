using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Statuses;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;

public sealed class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow
{
    internal GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow(
        Id<ApprovalWorkflowInternal> id,
        ApprovalWorkflowStageInternal[] stages,
        Id<EmployeeInternal>[] ownersIds,
        ApprovalRuleKeyInternal? approvalRuleKey,
        Audit<ApprovalWorkflowInternal> audit,
        UtcDateTime<ApprovalRouteInternal>? routeUpdatedDate,
        ApprovalWorkflowStatusInternal status)
    {
        Id = id;
        Stages = stages;
        OwnersIds = ownersIds;
        ApprovalRuleKey = approvalRuleKey;
        Audit = audit;
        RouteUpdatedDate = routeUpdatedDate;
        Status = status;
    }

    public Id<ApprovalWorkflowInternal> Id { get; }
    public ApprovalWorkflowStageInternal[] Stages { get; }
    public Id<EmployeeInternal>[] OwnersIds { get; }
    public ApprovalRuleKeyInternal? ApprovalRuleKey { get; }
    public Audit<ApprovalWorkflowInternal> Audit { get; }
    public UtcDateTime<ApprovalRouteInternal>? RouteUpdatedDate { get; }
    public ApprovalWorkflowStatusInternal Status { get; }
}
