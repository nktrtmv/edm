using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Complete.Completers.Workflow.Groups;

internal static class ApprovalWorkflowGroupCompleter
{
    internal static void Complete(
        ApprovalWorkflowGroup group,
        Id<Employee> executorId,
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        string? completionComment)
    {
        ApprovalWorkflowAssignment[] activeAssignments = group.Assignments.Where(a => a.IsActive).ToArray();

        foreach (ApprovalWorkflowAssignment assignment in activeAssignments)
        {
            if (assignment.ExecutorId == executorId)
            {
                ApprovalWorkflowAssignmentStateUpdater.SetManuallyCompleted(assignment, completionReason, completionComment);
            }
            else
            {
                ApprovalWorkflowAssignmentStateUpdater.SetAutoCompleted(assignment);
            }
        }

        group.SetStatus(ApprovalWorkflowGroupStatus.Completed);
    }

    internal static void CompleteAutomatically(ApprovalWorkflowGroup group)
    {
        ApprovalWorkflowAssignment[] activeAssignments = group.Assignments.Where(a => a.IsActive).ToArray();

        foreach (ApprovalWorkflowAssignment assignment in activeAssignments)
        {
            ApprovalWorkflowAssignmentStateUpdater.SetAutoCompleted(assignment);
        }

        group.SetStatus(ApprovalWorkflowGroupStatus.Completed);
    }
}
