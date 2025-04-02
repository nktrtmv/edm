using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    Statuses;

internal static class EntitiesApprovalWorkflowAssignmentStatusExternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentStatusExternal FromDto(EntitiesApprovalWorkflowAssignmentStatusDto status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowAssignmentStatusDto.NotStarted => EntitiesApprovalWorkflowAssignmentStatusExternal.NotStarted,
            EntitiesApprovalWorkflowAssignmentStatusDto.InProgress => EntitiesApprovalWorkflowAssignmentStatusExternal.InProgress,
            EntitiesApprovalWorkflowAssignmentStatusDto.Completed => EntitiesApprovalWorkflowAssignmentStatusExternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
