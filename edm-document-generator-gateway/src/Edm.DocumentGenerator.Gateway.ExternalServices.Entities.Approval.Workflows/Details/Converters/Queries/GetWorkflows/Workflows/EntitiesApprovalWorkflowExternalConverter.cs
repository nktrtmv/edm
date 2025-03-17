using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.ApprovalRulesKeys;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows;

internal static class EntitiesApprovalWorkflowExternalConverter
{
    internal static EntitiesApprovalWorkflowExternal FromDto(GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow workflow)
    {
        EntitiesApprovalWorkflowStageExternal[] stages =
            workflow.Stages.Select(EntitiesApprovalWorkflowStageExternalConverter.FromDto).ToArray();

        string[] ownersIds = workflow.OwnersIds.ToArray();

        var approvalRuleKey =
            NullableConverter.Convert(workflow.ApprovalRuleKey, ApprovalRuleKeyExternalConverter.FromDto);

        var status = ApprovalWorkflowStatusExternalConverter.FromDto(workflow.Status);

        var result = new EntitiesApprovalWorkflowExternal(workflow.Id, stages, ownersIds, approvalRuleKey, workflow.RouteUpdatedDate?.ToDateTime(), status);

        return result;
    }
}
