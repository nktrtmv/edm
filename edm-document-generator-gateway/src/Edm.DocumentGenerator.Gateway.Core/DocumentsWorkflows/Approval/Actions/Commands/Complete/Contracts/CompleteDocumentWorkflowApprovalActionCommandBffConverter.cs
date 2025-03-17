using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts.CompletionReasons;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Complete.Contracts;

internal static class CompleteDocumentWorkflowApprovalActionCommandBffConverter
{
    internal static CompleteEntitiesApprovalWorkflowsActionsCommandExternal ToExternal(CompleteDocumentWorkflowApprovalActionCommandBff command, UserBff user)
    {
        var context = DocumentWorkflowApprovalActionsContextBffConverter.ToExternal(command.Context, user);

        var completionReason =
            DocumentWorkflowApprovalActionCompletionReasonBffConverter.ToExternal(command.CompletionReason);

        var result = new CompleteEntitiesApprovalWorkflowsActionsCommandExternal(
            context,
            completionReason,
            command.CompletionComment,
            command.CurrentUserIsOwner,
            user.IsAdmin);

        return result;
    }
}
