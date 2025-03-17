using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents;

public sealed class DocumentWorkflowSigningDocumentBff
{
    public required string? EdoId { get; init; }
    public required string DocumentAttachmentId { get; init; }
    public required string? SignatureAttachmentId { get; init; }
    public required DocumentWorkflowSigningDocumentStateBff State { get; init; }
}
