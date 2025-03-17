using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.ApprovalRulesKeys;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Markers;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.ApprovalRulesKeys;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows;

internal static class EntitiesApprovalWorkflowExternalConverter
{
    internal static EntitiesApprovalWorkflowExternal FromDto(GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow workflow)
    {
        Id<EntitiesApprovalWorkflowExternal> id = IdConverterFrom<EntitiesApprovalWorkflowExternal>.FromString(workflow.Id);

        EntitiesApprovalWorkflowStageExternal[] stages =
            workflow.Stages.Select(EntitiesApprovalWorkflowStageExternalConverter.FromDto).ToArray();

        ApprovalRuleKeyExternal? approvalRuleKey =
            NullableConverter.Convert(workflow.ApprovalRuleKey, ApprovalRuleKeyExternalConverter.FromDto);

        UtcDateTime<EntitiesApprovalWorkflowExternal> updatedAt = UtcDateTimeConverterFrom<EntitiesApprovalWorkflowExternal>.FromTimestamp(workflow.Audit.UpdatedAt);

        UtcDateTime<ApprovalRouteExternal>? routeUpdatedDate =
            NullableConverter.Convert(workflow.RouteUpdatedDate, UtcDateTimeConverterFrom<ApprovalRouteExternal>.FromTimestamp);

        var result = new EntitiesApprovalWorkflowExternal(id, stages, approvalRuleKey, updatedAt, routeUpdatedDate, (int)workflow.Status);

        return result;
    }
}
