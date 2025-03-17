using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted.Statuses;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;

public sealed class WorkflowCompletedEntitiesSigningWorkflowResultInternal : EntitiesSigningWorkflowsResultInternal
{
    public WorkflowCompletedEntitiesSigningWorkflowResultInternal(
        Id<EntityDomain> domainId,
        Id<Entity> entityId,
        Id<SigningWorkflow> workflowId,
        WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal status,
        Id<User> currentUserId) : base(domainId)
    {
        EntityId = entityId;
        WorkflowId = workflowId;
        Status = status;
        CurrentUserId = currentUserId;
    }

    public Id<Entity> EntityId { get; }
    public Id<SigningWorkflow> WorkflowId { get; }
    public WorkflowCompletedEntitiesSigningWorkflowResultStatusInternal Status { get; }
    public Id<User> CurrentUserId { get; }
}
