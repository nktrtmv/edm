using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;

public abstract class EntitiesSigningWorkflowsEventInternal
{
    protected EntitiesSigningWorkflowsEventInternal(
        Id<EntityDomain> domainId,
        Id<Entity> entityId,
        Id<SigningWorkflow> workflowId)
    {
        DomainId = domainId;
        EntityId = entityId;
        WorkflowId = workflowId;
    }

    public Id<EntityDomain> DomainId { get; }
    public Id<Entity> EntityId { get; }
    public Id<SigningWorkflow> WorkflowId { get; }
}
