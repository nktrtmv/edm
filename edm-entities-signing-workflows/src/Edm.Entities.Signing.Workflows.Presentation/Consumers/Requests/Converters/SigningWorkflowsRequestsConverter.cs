using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Markers;
using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.CreateWorkflow;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.UpdateExecutors;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters.UpdateResponsibleManagers;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters;

internal static class SigningWorkflowsRequestsConverter
{
    internal static EntitiesSigningWorkflowsRequestInternal ToInternal(EntitiesSigningWorkflowsRequestsValue value)
    {
        Id<EntityDomainInternal> domainId = IdConverterFrom<EntityDomainInternal>.FromString(value.DomainId);

        EntitiesSigningWorkflowsRequestInternal result = value.RequestCase switch
        {
            EntitiesSigningWorkflowsRequestsValue.RequestOneofCase.CreateWorkflow =>
                CreateWorkflowEntitiesSigningWorkflowRequestConverter.ToInternal(value.CreateWorkflow, domainId),

            EntitiesSigningWorkflowsRequestsValue.RequestOneofCase.UpdateExecutors =>
                UpdateExecutorsEntitiesSigningWorkflowRequestConverter.ToInternal(value.UpdateExecutors, domainId),

            EntitiesSigningWorkflowsRequestsValue.RequestOneofCase.UpdateResponsibleManager =>
                UpdateResponsibleManagerEntitiesSigningWorkflowRequestConverter.ToInternal(value.UpdateResponsibleManager, domainId),

            _ => throw new ArgumentTypeOutOfRangeException(value.RequestCase)
        };

        return result;
    }
}
