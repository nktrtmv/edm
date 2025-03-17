namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows;

public interface IWorkflowsServiceClient
{
    Task DeleteWorkflowsByEntitiesIds(string domainId, string[] entitiesIds, CancellationToken cancellationToken);
}
