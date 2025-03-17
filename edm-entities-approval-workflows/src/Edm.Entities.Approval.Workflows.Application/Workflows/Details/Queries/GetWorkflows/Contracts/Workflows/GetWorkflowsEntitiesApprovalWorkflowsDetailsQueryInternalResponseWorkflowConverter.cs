using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.ApprovalRulesKeys;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Statuses;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;

internal static class GetEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflowConverter
{
    internal static GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow FromDomain(ApprovalWorkflow workflow)
    {
        Id<ApprovalWorkflowInternal> id = IdConverterFrom<ApprovalWorkflowInternal>.From(workflow.Id);

        ApprovalWorkflowStageInternal[] stages = workflow.State.Stages.Select(ApprovalWorkflowStageInternalConverter.FromDomain).ToArray();

        Id<EmployeeInternal>[] ownersIds = workflow.State.OwnersIds.Select(IdConverterFrom<EmployeeInternal>.From).ToArray();

        ApprovalRuleKeyInternal? approvalRuleKey = NullableConverter.Convert(workflow.Parameters.ApprovalRuleKey, ApprovalRuleKeyInternalConverter.FromDomain);

        Audit<ApprovalWorkflowInternal> audit = AuditConverterFrom<ApprovalWorkflowInternal>.From(workflow.Audit);

        UtcDateTime<ApprovalRouteInternal>? routeUpdatedDate =
            NullableConverter.Convert(workflow.Parameters.RouteUpdatedDate, UtcDateTimeConverterFrom<ApprovalRouteInternal>.From);

        ApprovalWorkflowStatusInternal status = ApprovalWorkflowStatusInternalConverter.FromDomain(workflow.Status);

        var result = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow(
            id,
            stages,
            ownersIds,
            approvalRuleKey,
            audit,
            routeUpdatedDate,
            status);

        return result;
    }
}
