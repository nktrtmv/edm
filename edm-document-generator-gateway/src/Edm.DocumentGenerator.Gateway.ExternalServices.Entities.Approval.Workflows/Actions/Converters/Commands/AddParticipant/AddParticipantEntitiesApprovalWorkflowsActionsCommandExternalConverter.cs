using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.AddParticipant;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.AddParticipant;

internal static class AddParticipantEntitiesApprovalWorkflowsActionsCommandExternalConverter
{
    public static AddParticipantEntitiesApprovalWorkflowsActionsCommand ToDto(AddParticipantEntitiesApprovalWorkflowsActionsCommandExternal command)
    {
        var context = EntitiesApprovalWorkflowActionContextExternalConverter.ToDto(
            command.Context,
            command.CurrentUserIsOwner,
            command.CurrentUserIsAdmin);

        var result = new AddParticipantEntitiesApprovalWorkflowsActionsCommand
        {
            Context = context,
            NewParticipantId = command.NewParticipantId,
            GroupId = command.GroupId,
            GroupName = command.GroupName,
            Comment = command.Comment
        };

        return result;
    }
}
