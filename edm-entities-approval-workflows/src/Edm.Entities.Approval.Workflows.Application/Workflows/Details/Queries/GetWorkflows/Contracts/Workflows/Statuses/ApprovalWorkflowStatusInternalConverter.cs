using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Statuses;

internal static class ApprovalWorkflowStatusInternalConverter
{
    internal static ApprovalWorkflowStatusInternal FromDomain(ApprovalWorkflowStatus status)
    {
        ApprovalWorkflowStatusInternal result = status switch
        {
            ApprovalWorkflowStatus.NotStarted => ApprovalWorkflowStatusInternal.NotStarted,
            ApprovalWorkflowStatus.InProgress => ApprovalWorkflowStatusInternal.InProgress,
            ApprovalWorkflowStatus.Approved => ApprovalWorkflowStatusInternal.Approved,
            ApprovalWorkflowStatus.Rejected => ApprovalWorkflowStatusInternal.Rejected,
            ApprovalWorkflowStatus.ReturnedToRework => ApprovalWorkflowStatusInternal.ReturnedToRework,
            ApprovalWorkflowStatus.ApprovedWithRemark => ApprovalWorkflowStatusInternal.ApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
