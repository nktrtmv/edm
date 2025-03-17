using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Delegate;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.Delegate.Contracts;

internal static class DelegateDocumentWorkflowApprovalActionCommandBffConverter
{
    internal static DelegateEntitiesApprovalWorkflowsActionsCommandExternal ToExternal(DelegateDocumentWorkflowApprovalActionCommandBff command, UserBff user)
    {
        var context = DocumentWorkflowApprovalActionsContextBffConverter.ToExternal(command.Context, user);

        var result = new DelegateEntitiesApprovalWorkflowsActionsCommandExternal(
            context,
            command.DelegateFromUserId,
            command.DelegateToUserId,
            command.Comment,
            command.CurrentUserIsOwner,
            user.IsAdmin);

        return result;
    }
}
