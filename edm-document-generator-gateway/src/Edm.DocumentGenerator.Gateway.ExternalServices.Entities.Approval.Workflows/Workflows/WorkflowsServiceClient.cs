using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Workflows;

internal sealed class WorkflowsServiceClient(EntitiesApprovalWorkflowsService.EntitiesApprovalWorkflowsServiceClient workflowsServiceClient) : IWorkflowsServiceClient
{
    public async Task DeleteWorkflowsByEntitiesIds(string domainId, string[] entitiesIds, CancellationToken cancellationToken)
    {
        await workflowsServiceClient.DeleteWorkflowsByEntitiesIdsAsync(
            new DeleteWorkflowsByEntitiesIdsCommand
            {
                DomainId = domainId,
                EntitiesIds = { entitiesIds }
            },
            cancellationToken: cancellationToken);
    }
}
