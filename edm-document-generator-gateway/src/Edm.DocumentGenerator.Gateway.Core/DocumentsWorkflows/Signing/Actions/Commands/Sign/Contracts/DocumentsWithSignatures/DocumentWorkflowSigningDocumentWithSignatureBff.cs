using JetBrains.Annotations;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Actions.Commands.Sign.Contracts.DocumentsWithSignatures;

[UsedImplicitly]
public sealed class DocumentWorkflowSigningDocumentWithSignatureBff
{
    public required string DocumentAttachmentId { get; init; }
    public required string SignatureAttachmentId { get; init; }
}
