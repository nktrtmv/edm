using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails.CompletionReasons;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    CompletionReasons;

internal static class EntitiesApprovalWorkflowAssignmentCompletionReasonExternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionReasonExternal FromDto(EntitiesApprovalWorkflowAssignmentCompletionReasonDto completionReason)
    {
        var result = completionReason switch
        {
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Approved => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Approved,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ApprovedWithRemark,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.ReturnedToRework,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Rejected => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Rejected,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Delegated => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal.Delegated,
            EntitiesApprovalWorkflowAssignmentCompletionReasonDto.CompletedAutomatically => EntitiesApprovalWorkflowAssignmentCompletionReasonExternal
                .CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
