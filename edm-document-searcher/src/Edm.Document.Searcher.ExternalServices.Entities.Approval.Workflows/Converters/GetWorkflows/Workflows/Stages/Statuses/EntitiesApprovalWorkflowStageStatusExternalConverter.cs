using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Statuses;

internal static class EntitiesApprovalWorkflowStageStatusExternalConverter
{
    internal static EntitiesApprovalWorkflowStageStatusExternal FromDto(EntitiesApprovalWorkflowStageStatusDto status)
    {
        EntitiesApprovalWorkflowStageStatusExternal result = status switch
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
