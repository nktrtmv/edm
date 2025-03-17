using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.ContractorSigned;

public sealed class ContractorSignedEntitiesEntitiesSigningWorkflowsEventInternal : EntitiesSigningWorkflowsEventInternal
{
    public ContractorSignedEntitiesEntitiesSigningWorkflowsEventInternal(
        Id<EntityDomain> domainId,
        Id<Entity> entityId,
        Id<SigningWorkflow> workflowId)
        : base(domainId, entityId, workflowId)
    {
    }
}
