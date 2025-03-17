using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts;

public sealed class CreateWorkflowEntitiesSigningWorkflowRequestInternal : EntitiesSigningWorkflowsRequestInternal
{
    public CreateWorkflowEntitiesSigningWorkflowRequestInternal(
        Id<EntityDomainInternal> domainId,
        Id<EntityInternal> entityId,
        Id<SigningInternal> workflowId,
        SigningParametersInternal parameters,
        SigningPartyInternal[] parties) : base(domainId)
    {
        EntityId = entityId;
        WorkflowId = workflowId;
        Parameters = parameters;
        Parties = parties;
    }

    internal Id<EntityInternal> EntityId { get; }
    internal Id<SigningInternal> WorkflowId { get; }
    internal SigningParametersInternal Parameters { get; }
    internal SigningPartyInternal[] Parties { get; }
}
