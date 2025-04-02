using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parties;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parameters;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow.Converters.Parties;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow;

internal static class CreateWorkflowEntitiesSigningWorkflowRequestConverter
{
    internal static CreateWorkflowEntitiesSigningWorkflowRequestInternal ToInternal(
        CreateWorkflowEntitiesSigningWorkflowRequest command,
        Id<EntityDomainInternal> domainId)
    {
        Id<EntityInternal> entityId =
            IdConverterFrom<EntityInternal>.FromString(command.EntityId);

        Id<SigningInternal> workflowId =
            IdConverterFrom<SigningInternal>.FromString(command.WorkflowId);

        SigningPartyInternal[] parties =
            command.Parties.Select(SigningPartyDtoConverter.ToInternal).ToArray();

        SigningParametersInternal parameters = SigningParametersDtoConverter.ToInternal(command.Parameters);

        return new CreateWorkflowEntitiesSigningWorkflowRequestInternal(domainId, entityId, workflowId, parameters, parties);
    }
}
