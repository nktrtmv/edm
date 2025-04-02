using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Statuses;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Statuses;

internal static class EntitiesApprovalWorkflowStageStatusInternalConverter
{
    internal static EntitiesApprovalWorkflowStageStatusInternal FromExternal(EntitiesApprovalWorkflowStageStatusExternal status)
    {
        EntitiesApprovalWorkflowStageStatusInternal result = status switch
        {
            EntitiesApprovalWorkflowStageStatusExternal.InProgress => EntitiesApprovalWorkflowStageStatusInternal.InProgress,
            EntitiesApprovalWorkflowStageStatusExternal.NotStarted => EntitiesApprovalWorkflowStageStatusInternal.NotStarted,
            EntitiesApprovalWorkflowStageStatusExternal.Approved => EntitiesApprovalWorkflowStageStatusInternal.Approved,
            EntitiesApprovalWorkflowStageStatusExternal.Rejected => EntitiesApprovalWorkflowStageStatusInternal.Rejected,
            EntitiesApprovalWorkflowStageStatusExternal.ApprovedWithRemark => EntitiesApprovalWorkflowStageStatusInternal.ApprovedWithRemark,
            EntitiesApprovalWorkflowStageStatusExternal.ReturnedToRework => EntitiesApprovalWorkflowStageStatusInternal.ReturnedToRework,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
