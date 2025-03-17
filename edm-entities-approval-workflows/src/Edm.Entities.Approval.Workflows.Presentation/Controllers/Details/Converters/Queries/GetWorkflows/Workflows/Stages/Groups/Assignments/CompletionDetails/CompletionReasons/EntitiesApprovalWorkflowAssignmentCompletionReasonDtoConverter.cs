using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails.
    CompletionReasons;

internal static class EntitiesApprovalWorkflowAssignmentCompletionReasonDtoConverter
{
    internal static EntitiesApprovalWorkflowAssignmentCompletionReasonDto FromInternal(ApprovalWorkflowAssignmentCompletionReasonInternal completionReason)
    {
        EntitiesApprovalWorkflowAssignmentCompletionReasonDto result = completionReason switch
        {
            ApprovalWorkflowAssignmentCompletionReasonInternal.Delegated => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Delegated,
            ApprovalWorkflowAssignmentCompletionReasonInternal.Approved => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Approved,
            ApprovalWorkflowAssignmentCompletionReasonInternal.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ApprovedWithRemark,
            ApprovalWorkflowAssignmentCompletionReasonInternal.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.ReturnedToRework,
            ApprovalWorkflowAssignmentCompletionReasonInternal.Rejected => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.Rejected,
            ApprovalWorkflowAssignmentCompletionReasonInternal.CompletedAutomatically => EntitiesApprovalWorkflowAssignmentCompletionReasonDto.CompletedAutomatically,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
