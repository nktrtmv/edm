using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts.Inheritors.UpdateExecutor;

public sealed class UpdateExecutorEntitiesSigningWorkflowsRequestExternal : EntitiesSigningWorkflowsRequestExternal
{
    public UpdateExecutorEntitiesSigningWorkflowsRequestExternal(
        Document document,
        Id<User> executorId)
        : base(document)
    {
        ExecutorId = executorId;
    }

    public Id<User> ExecutorId { get; }
}
