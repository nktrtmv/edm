using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Abstractions;

public abstract class EntitiesSigningWorkflowsRequestInternal : IRequest
{
    protected EntitiesSigningWorkflowsRequestInternal(Id<EntityDomainInternal> domainId)
    {
        DomainId = domainId;
    }

    internal Id<EntityDomainInternal> DomainId { get; }
}
