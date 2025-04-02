using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Audits;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Converters.ApprovalRulesKeys;

using Google.Protobuf.WellKnownTypes;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows;

internal static class GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflowConverter
{
    internal static GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow FromInternal(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryInternalResponseWorkflow workflow)
    {
        var id = IdConverterTo.ToString(workflow.Id);

        EntitiesApprovalWorkflowStageDto[] stages =
            workflow.Stages.Select(EntitiesApprovalWorkflowStageDtoConverter.FromInternal).ToArray();

        string[] ownersIds = workflow.OwnersIds.Select(IdConverterTo.ToString).ToArray();

        ApprovalRuleKeyDto? approvalRuleKey =
            NullableConverter.Convert(workflow.ApprovalRuleKey, ApprovalRuleKeyDtoConverter.FromInternal);

        EntitiesApprovalWorkflowAuditDto audit = EntitiesApprovalWorkflowAuditDtoConverter.FromInternal(workflow.Audit);

        Timestamp? routeUpdatedDate = NullableConverter.Convert(workflow.RouteUpdatedDate, UtcDateTimeConverterTo.ToTimeStamp);

        EntitiesApprovalWorkflowStatusDto status = ApprovalWorkflowStatusDtoConverter.FromInternal(workflow.Status);

        var result = new GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow
        {
            Id = id,
            Stages = { stages },
            OwnersIds = { ownersIds },
            ApprovalRuleKey = approvalRuleKey,
            Audit = audit,
            RouteUpdatedDate = routeUpdatedDate,
            Status = status
        };

        return result;
    }
}
