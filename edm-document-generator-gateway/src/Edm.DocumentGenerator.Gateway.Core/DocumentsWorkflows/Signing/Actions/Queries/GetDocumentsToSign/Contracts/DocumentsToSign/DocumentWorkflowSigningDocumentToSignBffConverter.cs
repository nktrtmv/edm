using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Queries.GetDocumentsToSign.DocumentsToSign;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Queries.GetDocumentsToSign.Contracts.DocumentsToSign;

internal static class DocumentWorkflowSigningDocumentToSignBffConverter
{
    internal static DocumentWorkflowSigningDocumentToSignBff FromExternal(SigningWorkflowDocumentToSignExternal documentToSign)
    {
        var result = new DocumentWorkflowSigningDocumentToSignBff
        {
            DocumentAttachmentId = documentToSign.DocumentAttachmentId
        };

        return result;
    }
}
