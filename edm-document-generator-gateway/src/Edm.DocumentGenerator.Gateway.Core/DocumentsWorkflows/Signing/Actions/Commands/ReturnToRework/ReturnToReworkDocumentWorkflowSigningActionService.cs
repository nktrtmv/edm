using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.ReturnToRework.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.ReturnToRework;

public sealed class ReturnToReworkDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public ReturnToReworkDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
        : base(actions)
    {
    }

    public async Task<ReturnToReworkDocumentWorkflowSigningActionCommandBffResponse> ReturnToRework(
        ReturnToReworkDocumentWorkflowSigningActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var context = new SigningWorkflowActionContextExternal(command.WorkflowId, user.Id, user.IsAdmin);

        await Actions.ReturnToRework(context, command.Comment, cancellationToken);

        var result = new ReturnToReworkDocumentWorkflowSigningActionCommandBffResponse();

        return result;
    }
}
