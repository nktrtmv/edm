using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Statuses;

internal static class ApprovalWorkflowStageStatusInternalConverter
{
    public static ApprovalWorkflowStageStatusInternal FromDomain(ApprovalWorkflowStageStatus status)
    {
        ApprovalWorkflowStageStatusInternal result = status switch
        {
            ApprovalWorkflowStageStatus.Approved => ApprovalWorkflowStageStatusInternal.Approved,
            ApprovalWorkflowStageStatus.InProgress => ApprovalWorkflowStageStatusInternal.InProgress,
            ApprovalWorkflowStageStatus.Rejected => ApprovalWorkflowStageStatusInternal.Rejected,
            ApprovalWorkflowStageStatus.NotStarted => ApprovalWorkflowStageStatusInternal.NotStarted,
            ApprovalWorkflowStageStatus.ReturnedToRework => ApprovalWorkflowStageStatusInternal.ReturnedToRework,
            ApprovalWorkflowStageStatus.ApprovedWithRemark => ApprovalWorkflowStageStatusInternal.ApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
