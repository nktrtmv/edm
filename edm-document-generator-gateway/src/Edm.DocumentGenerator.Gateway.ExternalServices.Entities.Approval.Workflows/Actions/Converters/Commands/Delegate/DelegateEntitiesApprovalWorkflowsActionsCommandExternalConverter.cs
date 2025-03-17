using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Delegate;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.Delegate;

internal static class DelegateEntitiesApprovalWorkflowsActionsCommandExternalConverter
{
    public static DelegateEntitiesApprovalWorkflowsActionsCommand ToDto(DelegateEntitiesApprovalWorkflowsActionsCommandExternal command)
    {
        var context = EntitiesApprovalWorkflowActionContextExternalConverter.ToDto(
            command.Context,
            command.CurrentUserIsOwner,
            command.CurrentUserIsAdmin);

        var result = new DelegateEntitiesApprovalWorkflowsActionsCommand
        {
            Context = context,
            ExecutorFromId = command.DelegateFromUserId,
            ExecutorToId = command.DelegateToUserId,
            Comment = command.Comment
        };

        return result;
    }
}
