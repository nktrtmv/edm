using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Statuses;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups;

public static class EntitiesApprovalWorkflowGroupExternalConverter
{
    public static EntitiesApprovalWorkflowGroupExternal FromDto(EntitiesApprovalWorkflowGroupDto group)
    {
        EntitiesApprovalWorkflowGroupStatusExternal status = EntitiesApprovalWorkflowGroupStatusExternalConverter.FromDto(group.Status);
        EntitiesApprovalWorkflowAssignmentExternal[] assignments = group.Assignments.Select(EntitiesApprovalWorkflowAssignmentExternalConverter.FromDto).ToArray();

        var result = new EntitiesApprovalWorkflowGroupExternal(
            group.Id,
            group.Name,
            assignments,
            status);

        return result;
    }
}
