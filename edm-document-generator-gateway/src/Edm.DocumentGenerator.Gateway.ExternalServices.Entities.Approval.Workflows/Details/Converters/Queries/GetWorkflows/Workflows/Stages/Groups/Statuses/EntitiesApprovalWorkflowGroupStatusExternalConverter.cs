using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;

internal static class EntitiesApprovalWorkflowGroupStatusExternalConverter
{
    internal static EntitiesApprovalWorkflowGroupStatusExternal FromDto(EntitiesApprovalWorkflowGroupStatusDto status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowGroupStatusDto.NotStarted => EntitiesApprovalWorkflowGroupStatusExternal.NotStarted,
            EntitiesApprovalWorkflowGroupStatusDto.InProgress => EntitiesApprovalWorkflowGroupStatusExternal.InProgress,
            EntitiesApprovalWorkflowGroupStatusDto.Completed => EntitiesApprovalWorkflowGroupStatusExternal.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
