using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details.Archives.Types;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetArchiveDetails.Contracts;

public sealed class GetElectronicArchiveDetailsDocumentWorkflowSigningDetailsQueryBff
{
    public required string WorkflowId { get; init; }

    public required DocumentWorkflowSigningArchiveTypeBff ArchiveType { get; init; }
}
