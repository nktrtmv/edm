using Edm.Entities.Signing.Workflows.GenericSubdomain;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.ContractorSigned;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.SelfSigned;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Values.ContractorSigned;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Values.SelfSigned;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Values;

internal static class EntitiesSigningWorkflowsEventsValueConverter
{
    internal static EntitiesSigningWorkflowsEventsValue FromInternal(EntitiesSigningWorkflowsEventInternal message)
    {
        var domainId = IdConverterTo.ToString(message.DomainId);

        var entityId = IdConverterTo.ToString(message.EntityId);

        var signingId = IdConverterTo.ToString(message.WorkflowId);

        EntitiesSigningWorkflowsEventsValue result = message switch
        {
            SelfSignedEntitiesEntitiesSigningWorkflowsEventInternal =>
                SelfSignedEntitiesSigningWorkflowEventConverter.FromInternal(domainId, entityId, signingId),

            ContractorSignedEntitiesEntitiesSigningWorkflowsEventInternal =>
                ContractorSignedEntitiesSigningWorkflowEventConverter.FromInternal(domainId, entityId, signingId),

            _ => throw new ArgumentTypeOutOfRangeException(message)
        };

        return result;
    }
}
