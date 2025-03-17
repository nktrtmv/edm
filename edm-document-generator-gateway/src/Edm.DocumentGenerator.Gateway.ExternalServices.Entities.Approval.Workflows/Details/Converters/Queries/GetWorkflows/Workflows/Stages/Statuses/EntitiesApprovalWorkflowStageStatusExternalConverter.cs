using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Statuses;

internal static class EntitiesApprovalWorkflowStageStatusExternalConverter
{
    internal static EntitiesApprovalWorkflowStageStatusExternal FromDto(EntitiesApprovalWorkflowStageStatusDto status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowStageStatusDto.NotStarted => EntitiesApprovalWorkflowStageStatusExternal.NotStarted,
            EntitiesApprovalWorkflowStageStatusDto.InProgress => EntitiesApprovalWorkflowStageStatusExternal.InProgress,
            EntitiesApprovalWorkflowStageStatusDto.Approved => EntitiesApprovalWorkflowStageStatusExternal.Approved,
            EntitiesApprovalWorkflowStageStatusDto.Rejected => EntitiesApprovalWorkflowStageStatusExternal.Rejected,
            EntitiesApprovalWorkflowStageStatusDto.ApprovedWithRemark => EntitiesApprovalWorkflowStageStatusExternal.ApprovedWithRemark,
            EntitiesApprovalWorkflowStageStatusDto.ReturnedToRework => EntitiesApprovalWorkflowStageStatusExternal.ReturnedToRework,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
