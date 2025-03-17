using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.Complete.Reasons;

internal static class EntitiesApprovalWorkflowAssignmentCompleteReasonDtoConverter
{
    internal static ApprovalWorkflowAssignmentCompletionReasonInternal ToInternal(EntitiesApprovalWorkflowAssignmentCompleteReasonDto reason)
    {
        ApprovalWorkflowAssignmentCompletionReasonInternal result = reason switch
        {
            EntitiesApprovalWorkflowAssignmentCompleteReasonDto.Approved => ApprovalWorkflowAssignmentCompletionReasonInternal.Approved,
            EntitiesApprovalWorkflowAssignmentCompleteReasonDto.ApprovedWithRemark => ApprovalWorkflowAssignmentCompletionReasonInternal.ApprovedWithRemark,
            EntitiesApprovalWorkflowAssignmentCompleteReasonDto.Rejected => ApprovalWorkflowAssignmentCompletionReasonInternal.Rejected,
            EntitiesApprovalWorkflowAssignmentCompleteReasonDto.ReturnedToRework => ApprovalWorkflowAssignmentCompletionReasonInternal.ReturnedToRework,
            _ => throw new ArgumentTypeOutOfRangeException(reason)
        };

        return result;
    }
}
