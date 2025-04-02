using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.Presentation.Abstractions;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;

internal static class EntitiesApprovalWorkflowAssignmentCompletionReasonConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionReasonDto FromInternal(
        EntitiesApprovalWorkflowAssignmentCompletionReasonInternal completionReason)
    {
        return completionReason switch
        {
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.Approved => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Approved,
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ApprovedWithRemark,
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ReturnedToRework,
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.Rejected => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Rejected,
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.Delegated => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Delegated,
            EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.CompletedAutomatically => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.CompletedAutomatically,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
