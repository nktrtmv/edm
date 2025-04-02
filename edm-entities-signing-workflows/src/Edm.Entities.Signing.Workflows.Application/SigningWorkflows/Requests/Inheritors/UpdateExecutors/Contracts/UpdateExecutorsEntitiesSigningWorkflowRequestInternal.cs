using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.UpdateExecutors.Contracts;

public sealed class UpdateExecutorsEntitiesSigningWorkflowRequestInternal : EntitiesSigningWorkflowsRequestInternal
{
    public UpdateExecutorsEntitiesSigningWorkflowRequestInternal(
        Id<EntityDomainInternal> domainId,
        Id<SigningWorkflowInternal> workflowId,
        Id<UserInternal> executorId) : base(domainId)
    {
        WorkflowId = workflowId;
        ExecutorId = executorId;
    }

    public Id<SigningWorkflowInternal> WorkflowId { get; }
    public Id<UserInternal> ExecutorId { get; }
}
