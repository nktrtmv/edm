using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.UpdateResponsibleManager.Contracts;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.UpdateResponsibleManagers;

internal static class UpdateResponsibleManagerEntitiesSigningWorkflowRequestConverter
{
    internal static UpdateResponsibleManagerEntitiesSigningWorkflowRequestInternal ToInternal(
        UpdateResponsibleManagerEntitiesSigningWorkflowRequest request,
        Id<EntityDomainInternal> domainId)
    {
        Id<SigningWorkflowInternal> workflowId = IdConverterFrom<SigningWorkflowInternal>.FromString(request.WorkflowId);

        Id<UserInternal>? documentClerkId = NullableConverter.Convert(request.DocumentClerkId, IdConverterFrom<UserInternal>.FromString);

        var result = new UpdateResponsibleManagerEntitiesSigningWorkflowRequestInternal(domainId, workflowId, documentClerkId);

        return result;
    }
}
