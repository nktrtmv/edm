using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Services.GetDocumentsToSign.Contracts.DocumentsToSign;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Actions.Converters.Queries.GetDocumentsToSign.DocumentsToSign;

internal static class SigningWorkflowDocumentToSignExternalConverter
{
    internal static SigningWorkflowDocumentToSignExternal FromDto(SigningWorkflowDocumentToSignDto document)
    {
        var result = new SigningWorkflowDocumentToSignExternal(document.DocumentAttachmentId);

        return result;
    }
}
