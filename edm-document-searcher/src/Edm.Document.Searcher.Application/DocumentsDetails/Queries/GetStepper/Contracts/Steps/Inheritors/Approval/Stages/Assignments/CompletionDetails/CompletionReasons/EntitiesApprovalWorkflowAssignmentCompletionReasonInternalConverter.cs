using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails.CompletionReasons;
using Edm.Document.Searcher.GenericSubdomain.Exceptions;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;

internal static class EntitiesApprovalWorkflowAssignmentCompletionReasonInternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionReasonInternal FromExternal(EntitiesApprovalWorkflowAssignmentCompletionReasonExternal completionReason)
    {
        EntitiesApprovalWorkflowAssignmentCompletionReasonInternal result = completionReason switch
        {
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Approved => EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.Approved,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.ApprovedWithRemark,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.ReturnedToRework,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Rejected => EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.Rejected,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Delegated => EntitiesApprovalWorkflowAssignmentCompletionReasonInternal.Delegated,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.CompletedAutomatically => EntitiesApprovalWorkflowAssignmentCompletionReasonInternal
                .CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
