using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details;

public interface IEntitiesApprovalWorkflowsDetailsClient
{
    Task<EntitiesApprovalWorkflowExternal[]> GetWorkflows(
        GetWorkflowsEntitiesApprovalWorkflowsDetailsQueryExternal query,
        CancellationToken cancellationToken);
}
