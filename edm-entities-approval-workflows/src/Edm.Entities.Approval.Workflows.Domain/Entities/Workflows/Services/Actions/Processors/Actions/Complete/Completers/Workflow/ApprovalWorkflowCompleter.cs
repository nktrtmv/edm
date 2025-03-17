using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow;

internal static class ApprovalWorkflowCompleter
{
    internal static void Complete(ApprovalWorkflowActionContext context, ApprovalWorkflowStatus status, string? completionComment)
    {
        context.Workflow.State.SetStatus(status);

        var workflowCompleted = new WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent(context.CurrentUserId, completionComment);

        context.Workflow.ApplicationEvents.Add(workflowCompleted);
    }
}
