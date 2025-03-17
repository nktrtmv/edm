using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States.
    Validators.ActiveAssignments;

internal static class ApprovalWorkflowAssignmentIsActiveValidator
{
    internal static void Validate(ApprovalWorkflowAssignment assignment)
    {
        ValidateIsNotCompleted(assignment);

        ValidateStatus(assignment, ApprovalWorkflowAssignmentStatus.NotStarted, ApprovalWorkflowAssignmentStatus.InProgress);
    }

    private static void ValidateIsNotCompleted(ApprovalWorkflowAssignment assignment)
    {
        if (assignment.CompletionDetails is null)
        {
            return;
        }

        throw new ApplicationException($"Assignment should not have `CompletionDetails`.\nAssignment: {assignment}");
    }

    private static void ValidateStatus(ApprovalWorkflowAssignment assignment, params ApprovalWorkflowAssignmentStatus[] validStatuses)
    {
        if (validStatuses.Contains(assignment.Status))
        {
            return;
        }

        string[] validStatusesStrings = validStatuses.Select(s => s.ToString()).ToArray();

        string validStatusesString = string.Join(", ", validStatusesStrings);

        throw new ApplicationException(
            $"""
             Assignment status is not among valid statuses.
             Assignment: {assignment}
             ValidStatuses: [{validStatusesString}]
             """);
    }
}
