using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages.Statuses;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Statuses;

internal static class EntitiesApprovalWorkflowStageStatusDtoConverter
{
    internal static EntitiesApprovalWorkflowStageStatusDto FromInternal(ApprovalWorkflowStageStatusInternal status)
    {
        EntitiesApprovalWorkflowStageStatusDto result = status switch
        {
            ApprovalWorkflowStageStatusInternal.NotStarted => EntitiesApprovalWorkflowStageStatusDto.NotStarted,
            ApprovalWorkflowStageStatusInternal.InProgress => EntitiesApprovalWorkflowStageStatusDto.InProgress,
            ApprovalWorkflowStageStatusInternal.Approved => EntitiesApprovalWorkflowStageStatusDto.Approved,
            ApprovalWorkflowStageStatusInternal.ApprovedWithRemark => EntitiesApprovalWorkflowStageStatusDto.ApprovedWithRemark,
            ApprovalWorkflowStageStatusInternal.ReturnedToRework => EntitiesApprovalWorkflowStageStatusDto.ReturnedToRework,
            ApprovalWorkflowStageStatusInternal.Rejected => EntitiesApprovalWorkflowStageStatusDto.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
