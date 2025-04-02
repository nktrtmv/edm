using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.TakeInWork;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.TakeInWork;

internal static class TakeInWorkActionsEntitiesApprovalWorkflowsCommandExternalConverter
{
    public static TakeInWorkEntitiesApprovalWorkflowsActionsCommand ToDto(TakeInWorkEntitiesApprovalWorkflowsActionsCommandExternal command)
    {
        var context = EntitiesApprovalWorkflowActionContextExternalConverter.ToDto(
            command.Context,
            command.CurrentUserIsOwner,
            command.CurrentUserIsAdmin);

        var result = new TakeInWorkEntitiesApprovalWorkflowsActionsCommand
        {
            Context = context
        };

        return result;
    }
}
