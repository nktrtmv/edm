using Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts.Details;

namespace Edm.DocumentGenerator.Gateway.Core.DocumentsWorkflows.Signing.Details.Queries.GetElectronicDetails.Contracts;

public sealed class GetElectronicDetailsDocumentWorkflowSigningDetailsQueryBffResponse
{
    public required DocumentWorkflowSigningElectronicDetailsBff? Details { get; init; }
}
