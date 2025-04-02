using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Detectors;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Kinds;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Services.Validators.ActionIsAvailable;

internal static class ActionIsAvailableEntitiesApprovalWorkflowsValidator
{
    internal static void Validate(ApprovalWorkflowActionContext context, ApprovalWorkflowActionKind action)
    {
        HashSet<ApprovalWorkflowActionKind> availableActions = AvailableApprovalWorkflowActionsDetector.Detect(context);

        if (availableActions.Contains(action))
        {
            return;
        }

        string[] availableActionsAsStrings = availableActions.Select(a => a.ToString()).ToArray();

        string availableActionsAsString = string.Join(", ", availableActionsAsStrings);

        throw new ApplicationException(
            $"""
             Action {action} is not available.
             AvailableActions: [{availableActionsAsString}]
             Context: {context}
             """);
    }

    internal static void Validate(ApprovalWorkflowActionContext context, ApprovalWorkflowAssignmentCompletionReason completionReason)
    {
        ApprovalWorkflowActionKind action = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReason.Approved => ApprovalWorkflowActionKind.Approve,
            ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark => ApprovalWorkflowActionKind.ApproveWithRemark,
            ApprovalWorkflowAssignmentCompletionReason.Delegated => ApprovalWorkflowActionKind.Delegate,
            ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework => ApprovalWorkflowActionKind.ReturnToRework,
            ApprovalWorkflowAssignmentCompletionReason.Rejected => ApprovalWorkflowActionKind.Reject,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        Validate(context, action);
    }
}
