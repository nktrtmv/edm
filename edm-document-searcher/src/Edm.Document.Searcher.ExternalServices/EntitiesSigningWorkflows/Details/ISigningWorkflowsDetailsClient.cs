using Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details.Contracts.Queries.GetWorkflows;

namespace Edm.Document.Searcher.ExternalServices.EntitiesSigningWorkflows.Details;

public interface ISigningWorkflowsDetailsClient
{
    Task<GetWorkflowsSigningWorkflowDetailsQueryResponseExternal> GetWorkflows(string[] ids, CancellationToken cancellationToken);
}
