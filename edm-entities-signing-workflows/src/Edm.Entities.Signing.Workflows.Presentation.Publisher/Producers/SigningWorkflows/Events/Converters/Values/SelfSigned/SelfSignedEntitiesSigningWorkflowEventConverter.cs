using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Values.SelfSigned;

internal static class SelfSignedEntitiesSigningWorkflowEventConverter
{
    internal static EntitiesSigningWorkflowsEventsValue FromInternal(
        string domainId,
        string entityId,
        string signingId)
    {
        var selfSigned = new SelfSignedEntitiesSigningWorkflowEvent();

        var result = new EntitiesSigningWorkflowsEventsValue
        {
            DomainId = domainId,
            EntityId = entityId,
            SigningId = signingId,
            SelfSigned = selfSigned
        };

        return result;
    }
}
