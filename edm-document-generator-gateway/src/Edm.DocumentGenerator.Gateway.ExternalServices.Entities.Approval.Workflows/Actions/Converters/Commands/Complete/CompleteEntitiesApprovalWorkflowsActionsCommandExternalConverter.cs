using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.Complete.Reasons;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Actions.Contracts.Commands.Complete;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Actions.Converters.Commands.Complete;

internal static class CompleteEntitiesApprovalWorkflowsActionsCommandExternalConverter
{
    internal static CompleteEntitiesApprovalWorkflowsActionsCommand ToDto(CompleteEntitiesApprovalWorkflowsActionsCommandExternal command)
    {
        var context = EntitiesApprovalWorkflowActionContextExternalConverter.ToDto(
            command.Context,
            command.CurrentUserIsOwner,
            command.CurrentUserIsAdmin);

        var completionReason =
            EntitiesApprovalWorkflowAssignmentCompleteReasonExternalConverter.ToDto(command.CompletionReason);

        var result = new CompleteEntitiesApprovalWorkflowsActionsCommand
        {
            Context = context,
            CompletionReason = completionReason,
            Comment = command.CompletionComment
        };

        return result;
    }
}
