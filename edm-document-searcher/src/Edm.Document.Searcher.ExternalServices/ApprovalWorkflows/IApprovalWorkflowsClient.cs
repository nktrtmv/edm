using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.Markers;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.ExternalServices.ApprovalWorkflows;

public interface IApprovalWorkflowsClient
{
    Task<string[]> GetAllEntityApproversIds(Id<EntityExternal> id, CancellationToken cancellationToken);
    Task<string[]> GetCurrentEntityApproversIds(Id<EntityExternal> id, CancellationToken cancellationToken);
    Task<EntitiesApprovalWorkflowExternal[]> GetWorkflows(Id<EntitiesApprovalWorkflowExternal>[] ids, CancellationToken cancellationToken);
}
