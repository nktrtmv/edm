using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results.
    WorkflowCompleted;

public sealed class WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent(Id<Employee> completedByUserId, string? completionComment)
    : EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent
{
    public Id<Employee> CompletedByUserId { get; } = completedByUserId;

    public string? CompletionComment { get; } = completionComment;
}
