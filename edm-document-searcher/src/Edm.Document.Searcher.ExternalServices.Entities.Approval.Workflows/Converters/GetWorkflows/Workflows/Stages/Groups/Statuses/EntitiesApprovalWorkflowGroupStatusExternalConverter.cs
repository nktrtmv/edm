using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.
    Statuses;

public static class EntitiesApprovalWorkflowGroupStatusExternalConverter
{
    public static EntitiesApprovalWorkflowGroupStatusExternal FromDto(EntitiesApprovalWorkflowGroupStatusDto status)
    {
        EntitiesApprovalWorkflowGroupStatusExternal result = status switch
        {
            EntitiesApprovalWorkflowGroupStatusDto.NotStarted => EntitiesApprovalWorkflowGroupStatusExternal.NotStarted,
            EntitiesApprovalWorkflowGroupStatusDto.InProgress => EntitiesApprovalWorkflowGroupStatusExternal.InProgress,
            EntitiesApprovalWorkflowGroupStatusDto.Completed => EntitiesApprovalWorkflowGroupStatusExternal.Completed,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };

        return result;
    }
}
