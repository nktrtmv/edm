using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.Statuses;

internal static class ApprovalWorkflowAssignmentStatusInternalConverter
{
    internal static ApprovalWorkflowAssignmentStatusInternal FromDomain(ApprovalWorkflowAssignmentStatus status)
    {
        ApprovalWorkflowAssignmentStatusInternal result = status switch
        {
            ApprovalWorkflowAssignmentStatus.NotStarted => ApprovalWorkflowAssignmentStatusInternal.NotStarted,
            ApprovalWorkflowAssignmentStatus.InProgress => ApprovalWorkflowAssignmentStatusInternal.InProgress,
            ApprovalWorkflowAssignmentStatus.Completed => ApprovalWorkflowAssignmentStatusInternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
