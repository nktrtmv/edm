using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.PutIntoEffect.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.PutIntoEffect;

public sealed class PutIntoEffectDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public PutIntoEffectDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
        : base(actions)
    {
    }

    public async Task<PutIntoEffectDocumentWorkflowSigningActionCommandBffResponse> PutIntoEffect(
        PutIntoEffectDocumentWorkflowSigningActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var context = new SigningWorkflowActionContextExternal(command.WorkflowId, user.Id, user.IsAdmin);

        await Actions.PutIntoEffect(context, cancellationToken);

        var result = new PutIntoEffectDocumentWorkflowSigningActionCommandBffResponse();

        return result;
    }
}
