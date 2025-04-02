using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Statuses;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Statuses;

internal static class EntitiesApprovalWorkflowStageStatusConverter
{
    internal static EntitiesApprovalWorkflowStageStatusDto FromInternal(
        EntitiesApprovalWorkflowStageStatusInternal status)
    {
        return status switch
        {
            EntitiesApprovalWorkflowStageStatusInternal.NotStarted => EntitiesApprovalWorkflowStageStatusDto.NotStarted,
            EntitiesApprovalWorkflowStageStatusInternal.InProgress => EntitiesApprovalWorkflowStageStatusDto.InProgress,
            EntitiesApprovalWorkflowStageStatusInternal.Approved => EntitiesApprovalWorkflowStageStatusDto.Approved,
            EntitiesApprovalWorkflowStageStatusInternal.Rejected => EntitiesApprovalWorkflowStageStatusDto.Rejected,
            EntitiesApprovalWorkflowStageStatusInternal.ApprovedWithRemark => EntitiesApprovalWorkflowStageStatusDto.ApprovedWithRemark,
            EntitiesApprovalWorkflowStageStatusInternal.ReturnedToRework => EntitiesApprovalWorkflowStageStatusDto.ReturnedToRework,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
