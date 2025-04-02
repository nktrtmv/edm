using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts.Workflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts;

internal sealed record GetSigningWorkflowDocumentWorkflowsQueryResponse
{
    internal required SigningWorkflowDto[] Workflows { get; init; }
}
