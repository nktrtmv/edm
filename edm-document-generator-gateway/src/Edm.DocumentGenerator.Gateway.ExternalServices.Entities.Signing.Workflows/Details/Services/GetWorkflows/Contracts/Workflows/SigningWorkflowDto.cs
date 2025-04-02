using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts.Workflows;

public sealed class SigningWorkflowDto
{
    public required string Id { get; init; }
    public required SigningStageDetailsDto[] Stages { get; init; }
}
