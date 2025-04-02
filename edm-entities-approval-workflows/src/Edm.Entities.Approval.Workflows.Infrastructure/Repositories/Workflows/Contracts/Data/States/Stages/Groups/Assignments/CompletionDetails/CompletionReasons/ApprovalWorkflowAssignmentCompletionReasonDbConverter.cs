using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails.ValueObjects.CompletionReasons;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;

internal static class ApprovalWorkflowAssignmentCompletionReasonDbConverter
{
    internal static ApprovalWorkflowAssignmentCompletionReasonDb FromDomain(ApprovalWorkflowAssignmentCompletionReason completionReason)
    {
        ApprovalWorkflowAssignmentCompletionReasonDb result = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReason.Approved => ApprovalWorkflowAssignmentCompletionReasonDb.Approved,
            ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark => ApprovalWorkflowAssignmentCompletionReasonDb.ApprovedWithRemark,
            ApprovalWorkflowAssignmentCompletionReason.Delegated => ApprovalWorkflowAssignmentCompletionReasonDb.Delegated,
            ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework => ApprovalWorkflowAssignmentCompletionReasonDb.ReturnedToRework,
            ApprovalWorkflowAssignmentCompletionReason.Rejected => ApprovalWorkflowAssignmentCompletionReasonDb.Rejected,
            ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically => ApprovalWorkflowAssignmentCompletionReasonDb.CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }

    internal static ApprovalWorkflowAssignmentCompletionReason ToDomain(ApprovalWorkflowAssignmentCompletionReasonDb completionReason)
    {
        ApprovalWorkflowAssignmentCompletionReason result = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReasonDb.Approved => ApprovalWorkflowAssignmentCompletionReason.Approved,
            ApprovalWorkflowAssignmentCompletionReasonDb.ApprovedWithRemark => ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark,
            ApprovalWorkflowAssignmentCompletionReasonDb.Delegated => ApprovalWorkflowAssignmentCompletionReason.Delegated,
            ApprovalWorkflowAssignmentCompletionReasonDb.ReturnedToRework => ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework,
            ApprovalWorkflowAssignmentCompletionReasonDb.Rejected => ApprovalWorkflowAssignmentCompletionReason.Rejected,
            ApprovalWorkflowAssignmentCompletionReasonDb.CompletedAutomatically => ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }

    [Obsolete]
    internal static ApprovalWorkflowAssignmentCompletionReason ToDomainObsolete(ApprovalWorkflowAssignmentStatusDb status)
    {
        ApprovalWorkflowAssignmentCompletionReason result = status switch
        {
            ApprovalWorkflowAssignmentStatusDb.ApprovedObsolete => ApprovalWorkflowAssignmentCompletionReason.Approved,
            ApprovalWorkflowAssignmentStatusDb.ApprovedWithRemarkObsolete => ApprovalWorkflowAssignmentCompletionReason.ApprovedWithRemark,
            ApprovalWorkflowAssignmentStatusDb.DelegatedObsolete => ApprovalWorkflowAssignmentCompletionReason.Delegated,
            ApprovalWorkflowAssignmentStatusDb.ReturnedToReworkObsolete => ApprovalWorkflowAssignmentCompletionReason.ReturnedToRework,
            ApprovalWorkflowAssignmentStatusDb.RejectedObsolete => ApprovalWorkflowAssignmentCompletionReason.Rejected,
            ApprovalWorkflowAssignmentStatusDb.CompleteWithoutActionObsolete => ApprovalWorkflowAssignmentCompletionReason.CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
