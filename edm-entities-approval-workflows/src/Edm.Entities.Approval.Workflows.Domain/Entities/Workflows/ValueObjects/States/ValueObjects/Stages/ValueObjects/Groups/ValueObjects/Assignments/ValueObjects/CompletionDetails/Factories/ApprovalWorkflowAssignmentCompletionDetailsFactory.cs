using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.DelegationDetails;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.
    Factories;

public static class ApprovalWorkflowAssignmentCompletionDetailsFactory
{
    public static ApprovalWorkflowAssignmentCompletionDetails Create(
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        string? completionComment,
        ApprovalWorkflowAssignmentDelegationDetails? delegationDetails = null)
    {
        UtcDateTime<ApprovalWorkflowAssignment> completedDate = UtcDateTime<ApprovalWorkflowAssignment>.Now;

        ApprovalWorkflowAssignmentCompletionDetails result = CreateFromDb(completionReason, completedDate, completionComment, delegationDetails);

        return result;
    }

    public static ApprovalWorkflowAssignmentCompletionDetails CreateFromDb(
        ApprovalWorkflowAssignmentCompletionReason completionReason,
        UtcDateTime<ApprovalWorkflowAssignment> completedDate,
        string? comment,
        ApprovalWorkflowAssignmentDelegationDetails? delegationDetails)
    {
        var result = new ApprovalWorkflowAssignmentCompletionDetails(completionReason, completedDate, comment, delegationDetails);

        return result;
    }
}
