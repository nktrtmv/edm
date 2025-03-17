using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States.
    Validators.ActiveAssignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States.
    Validators.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails.ValueObjects.AutoDelegationKinds;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Services.States;

public static class ApprovalWorkflowAssignmentStateUpdater
{
    public static void SetStatus(ApprovalWorkflowAssignment assignment, ApprovalWorkflowAssignmentStatus status)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        assignment.SetStatus(status);
    }

    public static void SetNotStarted(ApprovalWorkflowAssignment assignment)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.NotStarted);
    }

    public static void SetInProgressAutomatically(ApprovalWorkflowAssignment assignment)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.InProgress);

        assignment.SetIsFixed(false);
    }

    public static void SetInProgressManually(ApprovalWorkflowAssignment assignment)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.InProgress);

        assignment.SetIsFixed(true);
    }

    public static void SetManuallyCompleted(
        ApprovalWorkflowAssignment assignment,
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        string? completionComment)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        ApprovalWorkflowAssignmentCompletionReasonValidator.Validate(
            assignment,
            completionReason,
            ApprovalWorkflowAssignmentCompletionReason.Approved,
            ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark,
            ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework,
            ApprovalWorkflowAssignmentCompletionReason.Rejected);

        ApprovalWorkflowAssignmentCompletionDetails completionDetails =
            ApprovalWorkflowAssignmentCompletionDetailsFactory.Create(completionReason, completionComment);

        assignment.SetCompletionDetails(completionDetails);
        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.Completed);
    }

    public static void SetAutoCompleted(ApprovalWorkflowAssignment assignment)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        ApprovalWorkflowAssignmentCompletionDetails completionDetails = ApprovalWorkflowAssignmentCompletionDetailsFactory.Create(
            ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically,
            null);

        assignment.SetCompletionDetails(completionDetails);
        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.Completed);
    }

    public static void SetManuallyDelegated(
        ApprovalWorkflowAssignment assignment,
        Id<ApprovalWorkflowAssignment> delegatedToId,
        string comment)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        var delegationDetails = new ApprovalWorkflowAssignmentDelegationDetails(delegatedToId, null);

        ApprovalWorkflowAssignmentCompletionDetails completionDetails = ApprovalWorkflowAssignmentCompletionDetailsFactory.Create(
            ApprovalWorkflowAssignmentCompletionReason.Delegated,
            comment,
            delegationDetails);

        assignment.SetCompletionDetails(completionDetails);
        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.Completed);
    }

    public static void SetAutoDelegated(
        ApprovalWorkflowAssignment assignment,
        Id<ApprovalWorkflowAssignment> delegatedToId,
        ApprovalWorkflowAssignmentAutoDelegationKind autoDelegationKind)
    {
        ApprovalWorkflowAssignmentIsActiveValidator.Validate(assignment);

        var delegationDetails = new ApprovalWorkflowAssignmentDelegationDetails(delegatedToId, autoDelegationKind);

        ApprovalWorkflowAssignmentCompletionDetails completionDetails = ApprovalWorkflowAssignmentCompletionDetailsFactory.Create(
            ApprovalWorkflowAssignmentCompletionReason.Delegated,
            null,
            delegationDetails);

        assignment.SetCompletionDetails(completionDetails);
        assignment.SetStatus(ApprovalWorkflowAssignmentStatus.Completed);
    }
}
