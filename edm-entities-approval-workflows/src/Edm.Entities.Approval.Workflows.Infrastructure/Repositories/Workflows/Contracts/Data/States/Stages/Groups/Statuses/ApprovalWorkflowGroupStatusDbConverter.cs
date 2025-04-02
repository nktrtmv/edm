using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Statuses;

internal static class ApprovalWorkflowGroupStatusDbConverter
{
    internal static ApprovalWorkflowGroupStatusDb FromDomain(ApprovalWorkflowGroupStatus status)
    {
        ApprovalWorkflowGroupStatusDb result = status switch
        {
            ApprovalWorkflowGroupStatus.NotStarted => ApprovalWorkflowGroupStatusDb.NotStarted,
            ApprovalWorkflowGroupStatus.InProgress => ApprovalWorkflowGroupStatusDb.InProgress,
            ApprovalWorkflowGroupStatus.Completed => ApprovalWorkflowGroupStatusDb.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalWorkflowGroupStatus ToDomain(ApprovalWorkflowGroupStatusDb status)
    {
        ApprovalWorkflowGroupStatus result = status switch
        {
            ApprovalWorkflowGroupStatusDb.NotStarted => ApprovalWorkflowGroupStatus.NotStarted,
            ApprovalWorkflowGroupStatusDb.InProgress => ApprovalWorkflowGroupStatus.InProgress,
            ApprovalWorkflowGroupStatusDb.Completed => ApprovalWorkflowGroupStatus.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    [Obsolete]
    internal static ApprovalWorkflowGroupStatus ToDomainObsolete(ApprovalWorkflowAssignment[] assignments)
    {
        if (!assignments.Any())
        {
            return ApprovalWorkflowGroupStatus.NotStarted;
        }

        if (assignments.All(a => a.IsCompleted))
        {
            return ApprovalWorkflowGroupStatus.Completed;
        }

        if (assignments.Any(a => a.IsActive))
        {
            return ApprovalWorkflowGroupStatus.InProgress;
        }

        return ApprovalWorkflowGroupStatus.NotStarted;
    }
}
