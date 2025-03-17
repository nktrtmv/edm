using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Statuses;

internal static class ApprovalWorkflowStageStatusDbConverter
{
    internal static ApprovalWorkflowStageStatusDb FromDomain(ApprovalWorkflowStageStatus status)
    {
        ApprovalWorkflowStageStatusDb result = status switch
        {
            ApprovalWorkflowStageStatus.NotStarted => ApprovalWorkflowStageStatusDb.NotStarted,
            ApprovalWorkflowStageStatus.InProgress => ApprovalWorkflowStageStatusDb.InProgress,
            ApprovalWorkflowStageStatus.Approved => ApprovalWorkflowStageStatusDb.Approved,
            ApprovalWorkflowStageStatus.ApprovedWithRemark => ApprovalWorkflowStageStatusDb.ApprovedWithRemark,
            ApprovalWorkflowStageStatus.ReturnedToRework => ApprovalWorkflowStageStatusDb.ReturnedToRework,
            ApprovalWorkflowStageStatus.Rejected => ApprovalWorkflowStageStatusDb.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static ApprovalWorkflowStageStatus ToDomain(ApprovalWorkflowStageStatusDb status)
    {
        ApprovalWorkflowStageStatus result = status switch
        {
            ApprovalWorkflowStageStatusDb.NotStarted => ApprovalWorkflowStageStatus.NotStarted,
            ApprovalWorkflowStageStatusDb.InProgress => ApprovalWorkflowStageStatus.InProgress,
            ApprovalWorkflowStageStatusDb.Approved => ApprovalWorkflowStageStatus.Approved,
            ApprovalWorkflowStageStatusDb.ApprovedWithRemark => ApprovalWorkflowStageStatus.ApprovedWithRemark,
            ApprovalWorkflowStageStatusDb.ReturnedToRework => ApprovalWorkflowStageStatus.ReturnedToRework,
            ApprovalWorkflowStageStatusDb.Rejected => ApprovalWorkflowStageStatus.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
