using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups;

internal static class EntitiesApprovalWorkflowGroupExternalConverter
{
    internal static EntitiesApprovalWorkflowGroupExternal FromDto(EntitiesApprovalWorkflowGroupDto group)
    {
        EntitiesApprovalWorkflowAssignmentExternal[] assignments = group.Assignments.Select(EntitiesApprovalWorkflowAssignmentExternalConverter.FromDto).ToArray();

        var status = EntitiesApprovalWorkflowGroupStatusExternalConverter.FromDto(group.Status);

        var result = new EntitiesApprovalWorkflowGroupExternal(group.Id, group.Name, assignments, status);

        return result;
    }
}
