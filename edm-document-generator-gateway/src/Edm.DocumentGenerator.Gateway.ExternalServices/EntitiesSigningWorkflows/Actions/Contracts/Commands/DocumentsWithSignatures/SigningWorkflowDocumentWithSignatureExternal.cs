namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Actions.Contracts.Commands.DocumentsWithSignatures;

public sealed class SigningWorkflowDocumentWithSignatureExternal
{
    public SigningWorkflowDocumentWithSignatureExternal(string documentAttachmentId, string signatureAttachmentId)
    {
        DocumentAttachmentId = documentAttachmentId;
        SignatureAttachmentId = signatureAttachmentId;
    }

    public string DocumentAttachmentId { get; }
    public string SignatureAttachmentId { get; }
}
