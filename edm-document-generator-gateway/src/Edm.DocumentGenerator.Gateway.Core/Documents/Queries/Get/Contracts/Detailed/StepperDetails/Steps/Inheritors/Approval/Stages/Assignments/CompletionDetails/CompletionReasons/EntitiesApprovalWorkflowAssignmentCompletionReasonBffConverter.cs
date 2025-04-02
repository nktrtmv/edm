using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.CompletionReasons;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails.
    CompletionReasons;

internal static class EntitiesApprovalWorkflowAssignmentCompletionReasonBffConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionReasonBff FromExternal(EntitiesApprovalWorkflowAssignmentCompletionReasonExternal completionReason)
    {
        var result = completionReason switch
        {
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Approved => EntitiesApprovalWorkflowAssignmentCompletionReasonBff.Approved,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompletionReasonBff.ApprovedWithRemark,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompletionReasonBff.ReturnedToRework,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Rejected => EntitiesApprovalWorkflowAssignmentCompletionReasonBff.Rejected,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Delegated => EntitiesApprovalWorkflowAssignmentCompletionReasonBff.Delegated,
            EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.CompletedAutomatically => EntitiesApprovalWorkflowAssignmentCompletionReasonBff
                .CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
