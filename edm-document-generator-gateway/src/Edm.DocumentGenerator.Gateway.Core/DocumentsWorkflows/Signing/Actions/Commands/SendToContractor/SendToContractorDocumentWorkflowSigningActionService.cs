using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.SendToContractor.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.SendToContractor;

public sealed class SendToContractorDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public SendToContractorDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
        : base(actions)
    {
    }

    public async Task<SendToContractorDocumentWorkflowSigningActionCommandBffResponse> SendToContractor(
        SendToContractorDocumentWorkflowSigningActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var context = new SigningWorkflowActionContextExternal(command.WorkflowId, user.Id, user.IsAdmin);

        await Actions.SendToContractor(context, cancellationToken);

        var result = new SendToContractorDocumentWorkflowSigningActionCommandBffResponse();

        return result;
    }
}
