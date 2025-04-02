using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.DocumentsWithSignatures;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts.DocumentsWithSignatures;

internal static class DocumentWorkflowSigningDocumentWithSignatureBffConverter
{
    internal static SigningWorkflowDocumentWithSignatureExternal ToExternal(DocumentWorkflowSigningDocumentWithSignatureBff document)
    {
        var result = new SigningWorkflowDocumentWithSignatureExternal(document.DocumentAttachmentId, document.SignatureAttachmentId);

        return result;
    }
}
