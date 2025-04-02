using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States.Statuses;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents.States;

public sealed class DocumentWorkflowSigningDocumentStateBff
{
    public required DocumentWorkflowSigningDocumentStatusBff Status { get; init; }
    public required string StatusDescription { get; init; }
    public required DateTime StatusChangedAt { get; init; }
}
