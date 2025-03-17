using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Statuses;

internal static class ApprovalWorkflowStatusDbConverter
{
    internal static ApprovalWorkflowStatusDb FromDomain(ApprovalWorkflowStatus status)
    {
        ApprovalWorkflowStatusDb result = status switch
        {
            ApprovalWorkflowStatus.NotStarted => ApprovalWorkflowStatusDb.NotStarted,
            ApprovalWorkflowStatus.InProgress => ApprovalWorkflowStatusDb.InProgress,
            ApprovalWorkflowStatus.Approved => ApprovalWorkflowStatusDb.Approved,
            ApprovalWorkflowStatus.ApprovedWithRemark => ApprovalWorkflowStatusDb.ApprovedWithRemark,
            ApprovalWorkflowStatus.ReturnedToRework => ApprovalWorkflowStatusDb.ReturnedToRework,
            ApprovalWorkflowStatus.Rejected => ApprovalWorkflowStatusDb.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalWorkflowStatus ToDomain(ApprovalWorkflowStatusDb status)
    {
        ApprovalWorkflowStatus result = status switch
        {
            ApprovalWorkflowStatusDb.NotStarted => ApprovalWorkflowStatus.NotStarted,
            ApprovalWorkflowStatusDb.InProgress => ApprovalWorkflowStatus.InProgress,
            ApprovalWorkflowStatusDb.Approved => ApprovalWorkflowStatus.Approved,
            ApprovalWorkflowStatusDb.ApprovedWithRemark => ApprovalWorkflowStatus.ApprovedWithRemark,
            ApprovalWorkflowStatusDb.ReturnedToRework => ApprovalWorkflowStatus.ReturnedToRework,
            ApprovalWorkflowStatusDb.Rejected => ApprovalWorkflowStatus.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static string ToString(ApprovalWorkflowStatus status)
    {
        string result = status switch
        {
            ApprovalWorkflowStatus.NotStarted => "not_started",
            ApprovalWorkflowStatus.InProgress => "in_progress",
            ApprovalWorkflowStatus.Approved => "approved",
            ApprovalWorkflowStatus.ApprovedWithRemark => "approved_with_remark",
            ApprovalWorkflowStatus.ReturnedToRework => "to_rework",
            ApprovalWorkflowStatus.Rejected => "rejected",
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
