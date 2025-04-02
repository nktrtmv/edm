using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.Statuses;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;

internal static class EntitiesApprovalWorkflowAssignmentStatusDtoConverter
{
    internal static EntitiesApprovalWorkflowAssignmentStatusDto FromInternal(ApprovalWorkflowAssignmentStatusInternal status)
    {
        EntitiesApprovalWorkflowAssignmentStatusDto result = status switch
        {
            ApprovalWorkflowAssignmentStatusInternal.NotStarted => EntitiesApprovalWorkflowAssignmentStatusDto.NotStarted,
            ApprovalWorkflowAssignmentStatusInternal.InProgress => EntitiesApprovalWorkflowAssignmentStatusDto.InProgress,
            ApprovalWorkflowAssignmentStatusInternal.Completed => EntitiesApprovalWorkflowAssignmentStatusDto.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
