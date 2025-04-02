using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts.DocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign;

public sealed class GetDocumentsToSignDocumentWorkflowSigningActionService : DocumentWorkflowSigningActionService
{
    public GetDocumentsToSignDocumentWorkflowSigningActionService(ISigningWorkflowsActionsClient actions) : base(actions)
    {
    }

    public async Task<GetDocumentsToSignDocumentWorkflowSigningActionQueryBffResponse> GetDocumentsToSign(
        GetDocumentsToSignDocumentWorkflowSigningActionQueryBff command,
        UserBff user,
        CancellationToken cancellationToken)
    {
        var request = new GetDocumentsToSignSigningWorkflowActionQueryExternal(command.WorkflowId, user.Id, user.IsAdmin);

        var response =
            await Actions.GetDocumentsToSign(request, cancellationToken);

        DocumentWorkflowSigningDocumentToSignBff[] documents =
            response.DocumentsToSign.Select(DocumentWorkflowSigningDocumentToSignBffConverter.FromExternal).ToArray();

        var result = new GetDocumentsToSignDocumentWorkflowSigningActionQueryBffResponse
        {
            Documents = documents
        };

        return result;
    }
}
