using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.Statuses;

internal static class ApprovalWorkflowAssignmentStatusDbConverter
{
    internal static ApprovalWorkflowAssignmentStatusDb FromDomain(ApprovalWorkflowAssignmentStatus type)
    {
        ApprovalWorkflowAssignmentStatusDb result = type switch
        {
            ApprovalWorkflowAssignmentStatus.NotStarted => ApprovalWorkflowAssignmentStatusDb.NotStarted,
            ApprovalWorkflowAssignmentStatus.InProgress => ApprovalWorkflowAssignmentStatusDb.InProgress,
            ApprovalWorkflowAssignmentStatus.Completed => ApprovalWorkflowAssignmentStatusDb.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    internal static ApprovalWorkflowAssignmentStatus ToDomain(ApprovalWorkflowAssignmentStatusDb type)
    {
        ApprovalWorkflowAssignmentStatus result = type switch
        {
            ApprovalWorkflowAssignmentStatusDb.NotStarted => ApprovalWorkflowAssignmentStatus.NotStarted,
            ApprovalWorkflowAssignmentStatusDb.InProgress => ApprovalWorkflowAssignmentStatus.InProgress,
            ApprovalWorkflowAssignmentStatusDb.Completed => ApprovalWorkflowAssignmentStatus.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }

    [Obsolete]
    internal static ApprovalWorkflowAssignmentStatus ToDomainObsolete(ApprovalWorkflowAssignmentStatusDb type)
    {
        ApprovalWorkflowAssignmentStatus result = type switch
        {
            ApprovalWorkflowAssignmentStatusDb.NotStarted => ApprovalWorkflowAssignmentStatus.NotStarted,
            ApprovalWorkflowAssignmentStatusDb.InProgress => ApprovalWorkflowAssignmentStatus.InProgress,
            ApprovalWorkflowAssignmentStatusDb.Completed => ApprovalWorkflowAssignmentStatus.Completed,
            ApprovalWorkflowAssignmentStatusDb.ApprovedObsolete => ApprovalWorkflowAssignmentStatus.Completed,
            ApprovalWorkflowAssignmentStatusDb.ApprovedWithRemarkObsolete => ApprovalWorkflowAssignmentStatus.Completed,
            ApprovalWorkflowAssignmentStatusDb.RejectedObsolete => ApprovalWorkflowAssignmentStatus.Completed,
            ApprovalWorkflowAssignmentStatusDb.DelegatedObsolete => ApprovalWorkflowAssignmentStatus.Completed,
            ApprovalWorkflowAssignmentStatusDb.ReturnedToReworkObsolete => ApprovalWorkflowAssignmentStatus.Completed,
            ApprovalWorkflowAssignmentStatusDb.CompleteWithoutActionObsolete => ApprovalWorkflowAssignmentStatus.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(type)
        };

        return result;
    }
}
