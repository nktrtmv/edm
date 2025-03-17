using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests;

public interface IEntitiesApprovalWorkflowsRequestsSender
{
    Task Send(EntitiesApprovalWorkflowsRequestExternal request, CancellationToken cancellationToken);
}
