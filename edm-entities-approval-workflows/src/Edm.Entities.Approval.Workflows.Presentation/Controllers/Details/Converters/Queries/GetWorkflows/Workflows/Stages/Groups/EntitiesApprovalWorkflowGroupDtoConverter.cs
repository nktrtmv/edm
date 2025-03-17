using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups;

internal static class EntitiesApprovalWorkflowGroupDtoConverter
{
    internal static EntitiesApprovalWorkflowGroupDto FromInternal(ApprovalWorkflowGroupInternal group)
    {
        var id = group.Id.ToString();

        EntitiesApprovalWorkflowAssignmentDto[] assignments =
            group.Assignments.Select(EntitiesApprovalWorkflowAssignmentDtoConverter.FromInternal).ToArray();

        EntitiesApprovalWorkflowGroupStatusDto status =
            EntitiesApprovalWorkflowGroupStatusDtoConverter.FromInternal(group.Status);

        var result = new EntitiesApprovalWorkflowGroupDto
        {
            Id = id,
            Name = group.Name,
            Assignments = { assignments },
            Status = status
        };

        return result;
    }
}
