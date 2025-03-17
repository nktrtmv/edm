using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign;

internal sealed class GetDocumentsToSignSigningWorkflowActionService
{
    public GetDocumentsToSignSigningWorkflowActionService(SigningActionsService.SigningActionsServiceClient actions)
    {
        Actions = actions;
    }

    private SigningActionsService.SigningActionsServiceClient Actions { get; }

    internal async Task<GetDocumentsToSignSigningWorkflowQueryResponse> Get(
        GetDocumentsToSignSigningWorkflowActionQuery query,
        CancellationToken cancellationToken)
    {
        var context = new SigningActionContextDto
        {
            WorkflowId = query.WorkflowId,
            CurrentUserId = query.CurrentUserId,
            IsCurrentUserAdmin = query.IsCurrentUserAdmin
        };

        var request = new GetSigningDocumentsToSignQuery
        {
            Context = context
        };

        var response = await Actions.GetDocumentsToSignAsync(request, cancellationToken: cancellationToken);

        SigningWorkflowDocumentToSignDto[] documentsToSign = response.Documents.Select(SigningWorkflowDocumentToSignDtoConverter.FromDto).ToArray();

        var result = new GetDocumentsToSignSigningWorkflowQueryResponse
        {
            DocumentsToSign = documentsToSign
        };

        return result;
    }
}
