using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts.Workflows;

public sealed record SigningWorkflowDto(string Id, SigningStageDetailsDto[] Stages);
