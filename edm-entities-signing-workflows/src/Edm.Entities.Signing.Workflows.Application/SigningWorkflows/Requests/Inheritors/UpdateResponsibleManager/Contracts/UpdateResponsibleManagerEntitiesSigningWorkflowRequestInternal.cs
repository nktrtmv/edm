using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.UpdateResponsibleManager.Contracts;

public sealed class UpdateResponsibleManagerEntitiesSigningWorkflowRequestInternal : EntitiesSigningWorkflowsRequestInternal
{
    public UpdateResponsibleManagerEntitiesSigningWorkflowRequestInternal(
        Id<EntityDomainInternal> domainId,
        Id<SigningWorkflowInternal> workflowId,
        Id<UserInternal>? documentClerkId) : base(domainId)
    {
        WorkflowId = workflowId;
        DocumentClerkId = documentClerkId;
    }

    public Id<SigningWorkflowInternal> WorkflowId { get; }
    public Id<UserInternal>? DocumentClerkId { get; }
}
