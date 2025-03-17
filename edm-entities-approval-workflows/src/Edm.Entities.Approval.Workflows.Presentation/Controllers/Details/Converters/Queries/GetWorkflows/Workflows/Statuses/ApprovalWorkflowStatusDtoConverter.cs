using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Statuses;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Statuses;

internal static class ApprovalWorkflowStatusDtoConverter
{
    internal static EntitiesApprovalWorkflowStatusDto FromInternal(ApprovalWorkflowStatusInternal status)
    {
        EntitiesApprovalWorkflowStatusDto result = status switch
        {
            ApprovalWorkflowStatusInternal.NotStarted => EntitiesApprovalWorkflowStatusDto.NotStarted,
            ApprovalWorkflowStatusInternal.InProgress => EntitiesApprovalWorkflowStatusDto.InProgress,
            ApprovalWorkflowStatusInternal.Approved => EntitiesApprovalWorkflowStatusDto.Approved,
            ApprovalWorkflowStatusInternal.Rejected => EntitiesApprovalWorkflowStatusDto.Rejected,
            ApprovalWorkflowStatusInternal.ReturnedToRework => EntitiesApprovalWorkflowStatusDto.ReturnedToRework,
            ApprovalWorkflowStatusInternal.ApprovedWithRemark => EntitiesApprovalWorkflowStatusDto.ApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
