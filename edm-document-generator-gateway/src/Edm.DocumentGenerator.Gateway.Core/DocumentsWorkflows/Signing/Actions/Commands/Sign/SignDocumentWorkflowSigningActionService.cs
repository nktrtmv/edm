using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts.DocumentsWithSignatures;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.Contexts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.DocumentsWithSignatures;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign;

public sealed class SignDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public SignDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions)
        : base(actions)
    {
    }

    public async Task<SignDocumentWorkflowSigningActionCommandBffResponse> Sign(
        SignDocumentWorkflowSigningActionCommandBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var context = new SigningWorkflowActionContextExternal(command.WorkflowId, user.Id, user.IsAdmin);

        SigningWorkflowDocumentWithSignatureExternal[] documents =
            command.Documents.Select(DocumentWorkflowSigningDocumentWithSignatureBffConverter.ToExternal).ToArray();

        await Actions.Sign(context, documents, cancellationToken);

        var result = new SignDocumentWorkflowSigningActionCommandBffResponse();

        return result;
    }
}
