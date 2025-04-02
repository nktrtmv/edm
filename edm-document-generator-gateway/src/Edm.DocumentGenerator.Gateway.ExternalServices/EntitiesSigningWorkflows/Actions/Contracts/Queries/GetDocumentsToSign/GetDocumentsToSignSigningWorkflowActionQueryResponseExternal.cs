using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign;

public sealed class GetDocumentsToSignSigningWorkflowActionQueryResponseExternal
{
    public GetDocumentsToSignSigningWorkflowActionQueryResponseExternal(SigningWorkflowDocumentToSignExternal[] documentsToSign)
    {
        DocumentsToSign = documentsToSign;
    }

    public SigningWorkflowDocumentToSignExternal[] DocumentsToSign { get; }
}
