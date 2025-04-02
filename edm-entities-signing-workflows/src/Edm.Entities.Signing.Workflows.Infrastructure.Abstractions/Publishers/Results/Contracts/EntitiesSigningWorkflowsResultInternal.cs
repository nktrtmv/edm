using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;

public abstract class EntitiesSigningWorkflowsResultInternal
{
    protected EntitiesSigningWorkflowsResultInternal(Id<EntityDomain> domainId)
    {
        DomainId = domainId;
    }

    public Id<EntityDomain> DomainId { get; }
}
