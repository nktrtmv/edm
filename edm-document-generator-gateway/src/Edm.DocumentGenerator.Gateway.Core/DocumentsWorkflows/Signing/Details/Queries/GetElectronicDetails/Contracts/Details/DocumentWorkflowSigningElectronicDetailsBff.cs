using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives;
using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Documents;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details;

public sealed class DocumentWorkflowSigningElectronicDetailsBff
{
    public required string WorkflowId { get; init; }
    public required DocumentWorkflowSigningArchiveBff[] Archives { get; init; }
    public required DocumentWorkflowSigningDocumentBff[] Documents { get; init; }
}
