using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete.CompletionReason;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.Complete.Reasons;

internal static class EntitiesApprovalWorkflowAssignmentCompleteReasonExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentCompleteReasonDto ToDto(ReductionWorkflowActionCompletionReasonExternal completionReason)
    {
        var result = completionReason switch
        {
            ReductionWorkflowActionCompletionReasonExternal.Approved => EntitiesApprovalWorkflowAssignmentCompleteReasonDto.Approved,
            ReductionWorkflowActionCompletionReasonExternal.ApprovedWithRemark => EntitiesApprovalWorkflowAssignmentCompleteReasonDto.ApprovedWithRemark,
            ReductionWorkflowActionCompletionReasonExternal.ReturnedToRework => EntitiesApprovalWorkflowAssignmentCompleteReasonDto.ReturnedToRework,
            ReductionWorkflowActionCompletionReasonExternal.Rejected => EntitiesApprovalWorkflowAssignmentCompleteReasonDto.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
