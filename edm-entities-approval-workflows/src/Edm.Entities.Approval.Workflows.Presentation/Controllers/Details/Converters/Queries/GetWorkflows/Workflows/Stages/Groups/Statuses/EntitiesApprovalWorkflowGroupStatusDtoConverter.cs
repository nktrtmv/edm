using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Statuses;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

internal static class EntitiesApprovalWorkflowGroupStatusDtoConverter
{
    internal static EntitiesApprovalWorkflowGroupStatusDto FromInternal(ApprovalWorkflowGroupStatusInternal status)
    {
        EntitiesApprovalWorkflowGroupStatusDto result = status switch
        {
            ApprovalWorkflowGroupStatusInternal.NotStarted => EntitiesApprovalWorkflowGroupStatusDto.NotStarted,
            ApprovalWorkflowGroupStatusInternal.InProgress => EntitiesApprovalWorkflowGroupStatusDto.InProgress,
            ApprovalWorkflowGroupStatusInternal.Completed => EntitiesApprovalWorkflowGroupStatusDto.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
