using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.TakeInWork;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.TakeInWork.Contracts;

internal static class TakeInWorkDocumentWorkflowApprovalActionCommandBffConverter
{
    internal static TakeInWorkEntitiesApprovalWorkflowsActionsCommandExternal ToExternal(TakeInWorkDocumentWorkflowApprovalActionCommandBff command, UserBff user)
    {
        var context = DocumentWorkflowApprovalActionsContextBffConverter.ToExternal(command.Context, user);

        var result = new TakeInWorkEntitiesApprovalWorkflowsActionsCommandExternal(context, command.CurrentUserIsOwner, user.IsAdmin);

        return result;
    }
}
