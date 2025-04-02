using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States.
    Validators.CompletionReasons;

internal static class ApprovalWorkflowAssignmentCompletionReasonValidator
{
    internal static void Validate(
        ApprovalWorkflowAssignment assignment,
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        params ApprovalWorkflowAssignmentCompletionReason[] validCompletionReasons)
    {
        if (validCompletionReasons.Contains(completionReason))
        {
            return;
        }

        string[] validCompletionReasonsStrings = validCompletionReasons.Select(s => s.ToString()).ToArray();

        string validCompletionReasonsString = string.Join(", ", validCompletionReasonsStrings);

        throw new ApplicationException(
            $"""
             Assignment completion reason is not among valid completion reasons.
             Assignment: {assignment}
             CompletionReason: {completionReason}
             ValidCompletionReasons: [{validCompletionReasonsString}]
             """);
    }
}
