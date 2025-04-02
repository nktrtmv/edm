using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Contracts.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.AddParticipant;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Approval.Actions.Commands.AddParticipant.Contracts;

internal static class AddParticipantDocumentWorkflowApprovalActionCommandBffConverter
{
    internal static AddParticipantEntitiesApprovalWorkflowsActionsCommandExternal ToExternal(
        AddParticipantDocumentWorkflowApprovalActionCommandBff command,
        UserBff user)
    {
        var context = DocumentWorkflowApprovalActionsContextBffConverter.ToExternal(command.Context, user);

        var result = new AddParticipantEntitiesApprovalWorkflowsActionsCommandExternal(
            context,
            command.UserId,
            command.GroupId,
            command.GroupName,
            command.Comment,
            command.CurrentUserIsOwner,
            user.IsAdmin);

        return result;
    }
}
