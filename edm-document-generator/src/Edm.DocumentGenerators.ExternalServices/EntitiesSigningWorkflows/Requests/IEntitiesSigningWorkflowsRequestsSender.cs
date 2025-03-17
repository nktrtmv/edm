using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests;

public interface IEntitiesSigningWorkflowsRequestsSender
{
    Task Send(EntitiesSigningWorkflowsRequestExternal request, CancellationToken cancellationToken);
}
