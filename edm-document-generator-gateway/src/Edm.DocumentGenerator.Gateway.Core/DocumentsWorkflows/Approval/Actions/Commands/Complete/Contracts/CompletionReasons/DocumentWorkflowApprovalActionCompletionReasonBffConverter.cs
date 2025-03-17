using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete.CompletionReason;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts.CompletionReasons;

internal static class DocumentWorkflowApprovalActionCompletionReasonBffConverter
{
    public static ReductionWorkflowActionCompletionReasonExternal ToExternal(DocumentWorkflowApprovalActionCompletionReasonBff completionReason)
    {
        var result = completionReason switch
        {
            DocumentWorkflowApprovalActionCompletionReasonBff.Approved => ReductionWorkflowActionCompletionReasonExternal.Approved,
            DocumentWorkflowApprovalActionCompletionReasonBff.ApprovedWithRemark => ReductionWorkflowActionCompletionReasonExternal.ApprovedWithRemark,
            DocumentWorkflowApprovalActionCompletionReasonBff.ReturnedToRework => ReductionWorkflowActionCompletionReasonExternal.ReturnedToRework,
            DocumentWorkflowApprovalActionCompletionReasonBff.Rejected => ReductionWorkflowActionCompletionReasonExternal.Rejected,
            _ => throw new ArgumentTypeOutOfRangeException(completionReason)
        };

        return result;
    }
}
