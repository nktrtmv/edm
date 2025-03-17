using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Statuses;

internal static class ApprovalWorkflowGroupStatusInternalConverter
{
    internal static ApprovalWorkflowGroupStatusInternal FromDomain(ApprovalWorkflowGroupStatus status)
    {
        ApprovalWorkflowGroupStatusInternal result = status switch
        {
            ApprovalWorkflowGroupStatus.NotStarted => ApprovalWorkflowGroupStatusInternal.NotStarted,
            ApprovalWorkflowGroupStatus.InProgress => ApprovalWorkflowGroupStatusInternal.InProgress,
            ApprovalWorkflowGroupStatus.Completed => ApprovalWorkflowGroupStatusInternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
