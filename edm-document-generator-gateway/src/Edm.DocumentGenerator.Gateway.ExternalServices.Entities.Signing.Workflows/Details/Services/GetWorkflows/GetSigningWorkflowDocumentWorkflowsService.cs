using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts.Workflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows;

internal sealed class GetSigningWorkflowDocumentWorkflowsService
{
    public GetSigningWorkflowDocumentWorkflowsService(SigningDetailsService.SigningDetailsServiceClient details)
    {
        Details = details;
    }

    private SigningDetailsService.SigningDetailsServiceClient Details { get; }

    internal async Task<GetSigningWorkflowDocumentWorkflowsQueryResponse> Get(GetSigningWorkflowDocumentWorkflowsQuery query, CancellationToken cancellationToken)
    {
        SigningWorkflowDto[] workflows = await GetWorkflows(query, cancellationToken);

        var result = new GetSigningWorkflowDocumentWorkflowsQueryResponse
        {
            Workflows = workflows
        };

        return result;
    }

    private async Task<SigningWorkflowDto[]> GetWorkflows(GetSigningWorkflowDocumentWorkflowsQuery query, CancellationToken cancellationToken)
    {
        Task<SigningWorkflowDto>[] tasks = query.Ids.Select(i => GetWorkflow(i, cancellationToken)).ToArray();

        SigningWorkflowDto[] result = await Task.WhenAll(tasks);

        return result;
    }

    private async Task<SigningWorkflowDto> GetWorkflow(string workflowId, CancellationToken cancellationToken)
    {
        var request = new GetSigningStagesDetailsQuery
        {
            WorkflowId = workflowId
        };

        var response = await Details.GetStagesAsync(request, cancellationToken: cancellationToken);

        SigningStageDetailsDto[] stages = response.Stages.ToArray();

        var result = new SigningWorkflowDto
        {
            Id = workflowId,
            Stages = stages
        };

        return result;
    }
}
