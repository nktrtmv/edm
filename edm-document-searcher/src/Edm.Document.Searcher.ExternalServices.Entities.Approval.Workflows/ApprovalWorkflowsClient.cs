using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetAllExecutors;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetCurrentExecutors;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows;
using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Grpc.Core;

using Microsoft.Extensions.Logging;

using Polly;
using Polly.Retry;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows;

internal sealed class ApprovalWorkflowsClient(
    EntitiesApprovalWorkflowsDetailsService.EntitiesApprovalWorkflowsDetailsServiceClient client,
    ILogger<ApprovalWorkflowsClient> logger) : IApprovalWorkflowsClient
{
    private readonly AsyncRetryPolicy _policy = Policy.Handle<Exception>()
        .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2));

    async Task<string[]> IApprovalWorkflowsClient.GetAllEntityApproversIds(Id<EntityExternal> id, CancellationToken cancellationToken)
    {
        GetAllExecutorsEntitiesApprovalWorkflowsDetailsQuery query =
            GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter.FromExternal(id);

        GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse response = await TracingFacility.TraceGrpc(
            logger,
            nameof(IApprovalWorkflowsClient.GetAllEntityApproversIds),
            query,
            async () => await client.GetAllExecutorsAsync(query, cancellationToken: cancellationToken));

        string[] result = response.Executors.ToArray();

        return result;
    }

    async Task<string[]> IApprovalWorkflowsClient.GetCurrentEntityApproversIds(Id<EntityExternal> id, CancellationToken cancellationToken)
    {
        GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQuery query =
            GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryConverter.FromExternal(id);

        GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryResponse response = await TracingFacility.TraceGrpc(
            logger,
            nameof(IApprovalWorkflowsClient.GetCurrentEntityApproversIds),
            query,
            async () => await client.GetCurrentExecutorsAsync(query, cancellationToken: cancellationToken));

        string[] result = response.Executors.ToArray();

        return result;
    }

    async Task<EntitiesApprovalWorkflowExternal[]> IApprovalWorkflowsClient.GetWorkflows(Id<EntitiesApprovalWorkflowExternal>[] ids, CancellationToken cancellationToken)
    {
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery request =
            GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternalConverter.ToDto(ids);

        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow[] responseWorkflows =
            await _policy.ExecuteAsync(() => GetWorkflows(request, cancellationToken));

        EntitiesApprovalWorkflowExternal[] result = responseWorkflows.Select(EntitiesApprovalWorkflowExternalConverter.FromDto).ToArray();

        return result;
    }

    private async Task<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow[]> GetWorkflows(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQuery request,
        CancellationToken cancellationToken)
    {
        using AsyncServerStreamingCall<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow> call = client.GetWorkflows(
            request,
            cancellationToken: cancellationToken);

        var responseWorkflows = new List<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow>();

        await foreach (GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow workflow in call.ResponseStream.ReadAllAsync(cancellationToken))
        {
            responseWorkflows.Add(workflow);
        }

        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow[] result = responseWorkflows.ToArray();

        return result;
    }
}
