using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    CompletionReasons;

public static class EntitiesApprovalWorkflowAssignmentCompletionReasonExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentCompletionReasonExternal FromDto(EntitiesApprovalWorkflowAssignmentCompletionReasonDto completionReason)
    {
        EntitiesApprovalWorkflowAssignmentCompletionReasonExternal result = completionReason switch
        {
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Approved => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Approved,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ApprovedWithRemark,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ReturnedToRework,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Rejected => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Rejected,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Delegated => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Delegated,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.CompletedAutomatically => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.CompletedAutomatically,
            _ => throw new ArgumentOutOfRangeException(nameof(completionReason), completionReason, null)
        };

        return result;
    }
}
