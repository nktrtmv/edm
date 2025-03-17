using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;

public static class EntitiesApprovalWorkflowAssignmentStatusExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentStatusExternal FromDto(EntitiesApprovalWorkflowAssignmentStatusDto status)
    {
        EntitiesApprovalWorkflowAssignmentStatusExternal result = status switch
        {
            EntitiesApprovalWorkflowAssignmentStatusDto.NotStarted => EntitiesApprovalWorkflowAssignmentStatusExternal.NotStarted,
            EntitiesApprovalWorkflowAssignmentStatusDto.InProgress => EntitiesApprovalWorkflowAssignmentStatusExternal.InProgress,
            EntitiesApprovalWorkflowAssignmentStatusDto.Completed => EntitiesApprovalWorkflowAssignmentStatusExternal.Completed,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };

        return result;
    }
}
