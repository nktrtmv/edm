using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Converters.Queries.GetWorkflows.Workflows;
using Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details.Services.GetWorkflows.Contracts.Workflows;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Polly;
using Polly.Retry;

namespace Edm.Document.Searcher.ExternalServices.Entities.Signing.Workflows.Details;

internal sealed class SigningWorkflowsDetailsClient(SigningDetailsService.SigningDetailsServiceClient client) : ISigningWorkflowsDetailsClient
{
    private readonly AsyncRetryPolicy _policy = Policy.Handle<Exception>()
        .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2));

    async Task<GetWorkflowsSigningWorkflowDetailsQueryResponseExternal> ISigningWorkflowsDetailsClient.GetWorkflows(string[] ids, CancellationToken cancellationToken)
    {
        Task<SigningWorkflowDto>[] tasks = ids.Select(id => GetWorkflow(id, cancellationToken)).ToArray();

        SigningWorkflowDto[] response = await Task.WhenAll(tasks);

        SigningWorkflowExternal[] workflows = response.Select(SigningWorkflowExternalConverter.FromDto).ToArray();

        var result = new GetWorkflowsSigningWorkflowDetailsQueryResponseExternal(workflows);

        return result;
    }

    private async Task<SigningWorkflowDto> GetWorkflow(string workflowId, CancellationToken cancellationToken)
    {
        var request = new GetSigningStagesDetailsQuery
        {
            WorkflowId = workflowId
        };

        GetSigningStagesDetailsQueryResponse response =
            await _policy.ExecuteAsync(async () => await client.GetStagesAsync(request, cancellationToken: cancellationToken));

        SigningStageDetailsDto[] stages = response.Stages.ToArray();

        var result = new SigningWorkflowDto(workflowId, stages);

        return result;
    }
}
