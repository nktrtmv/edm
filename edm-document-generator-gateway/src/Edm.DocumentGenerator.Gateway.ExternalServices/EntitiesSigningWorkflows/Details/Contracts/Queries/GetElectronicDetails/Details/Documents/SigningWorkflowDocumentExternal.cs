using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents.States;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetElectronicDetails.Details.Documents;

public sealed class SigningWorkflowDocumentExternal
{
    public SigningWorkflowDocumentExternal(
        string? edoId,
        string documentAttachmentId,
        string? signatureAttachmentId,
        SigningWorkflowDocumentStateExternal state)
    {
        EdoId = edoId;
        DocumentAttachmentId = documentAttachmentId;
        SignatureAttachmentId = signatureAttachmentId;
        State = state;
    }

    public string? EdoId { get; }
    public string DocumentAttachmentId { get; }
    public string? SignatureAttachmentId { get; }
    public SigningWorkflowDocumentStateExternal State { get; }
}
