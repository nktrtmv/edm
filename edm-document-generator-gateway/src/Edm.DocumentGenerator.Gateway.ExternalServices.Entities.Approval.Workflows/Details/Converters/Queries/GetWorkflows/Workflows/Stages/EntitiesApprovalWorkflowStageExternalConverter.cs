using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Types;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages;

internal static class EntitiesApprovalWorkflowStageExternalConverter
{
    internal static EntitiesApprovalWorkflowStageExternal FromDto(EntitiesApprovalWorkflowStageDto stage)
    {
        var type = EntitiesApprovalWorkflowStageTypeExternalConverter.FromDto(stage.Type);

        var status = EntitiesApprovalWorkflowStageStatusExternalConverter.FromDto(stage.Status);

        EntitiesApprovalWorkflowGroupExternal[] groups = stage.Groups.Select(EntitiesApprovalWorkflowGroupExternalConverter.FromDto).ToArray();

        var startedDate = stage.StartedDate?.ToDateTime();

        var result = new EntitiesApprovalWorkflowStageExternal(stage.Id, type, status, groups, startedDate);

        return result;
    }
}
