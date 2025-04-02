using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.UpdateExecutors.Contracts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.UpdateExecutors;

internal static class UpdateExecutorsEntitiesSigningWorkflowRequestConverter
{
    internal static UpdateExecutorsEntitiesSigningWorkflowRequestInternal ToInternal(
        UpdateExecutorsEntitiesSigningWorkflowRequest request,
        Id<EntityDomainInternal> domainId)
    {
        Id<SigningWorkflowInternal> workflowId = IdConverterFrom<SigningWorkflowInternal>.FromString(request.WorkflowId);

        Id<UserInternal> executorId = IdConverterFrom<UserInternal>.FromString(request.ExecutorId);

        var result = new UpdateExecutorsEntitiesSigningWorkflowRequestInternal(domainId, workflowId, executorId);

        return result;
    }
}
