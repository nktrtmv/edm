using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Grpc.Core;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details;

internal sealed class EntitiesApprovalWorkflowsDetailsClient : IEntitiesApprovalWorkflowsDetailsClient
{
    public EntitiesApprovalWorkflowsDetailsClient(EntitiesApprovalWorkflowsDetailsService.EntitiesApprovalWorkflowsDetailsServiceClient details)
    {
        Details = details;
    }

    private EntitiesApprovalWorkflowsDetailsService.EntitiesApprovalWorkflowsDetailsServiceClient Details { get; }

    async Task<EntitiesApprovalWorkflowExternal[]> IEntitiesApprovalWorkflowsDetailsClient.GetWorkflows(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal query,
        CancellationToken cancellationToken)
    {
        var request =
            GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternalConverter.ToDto(query);

        using AsyncServerStreamingCall<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow> call = Details.GetWorkflows(
            request,
            cancellationToken: cancellationToken);

        var responseWorkflows = new List<GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryResponseWorkflow>();

        await foreach (var workflow in call.ResponseStream.ReadAllAsync(cancellationToken))
        {
            responseWorkflows.Add(workflow);
        }

        EntitiesApprovalWorkflowExternal[] result = responseWorkflows.Select(EntitiesApprovalWorkflowExternalConverter.FromDto).ToArray();

        return result;
    }
}
