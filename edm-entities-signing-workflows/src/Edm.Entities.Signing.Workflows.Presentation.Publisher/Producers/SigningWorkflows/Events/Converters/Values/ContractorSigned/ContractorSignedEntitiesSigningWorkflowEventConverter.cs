using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Values.ContractorSigned;

internal static class ContractorSignedEntitiesSigningWorkflowEventConverter
{
    internal static EntitiesSigningWorkflowsEventsValue FromInternal(
        string domainId,
        string entityId,
        string signingId)
    {
        var contractorSigned = new ContractorSignedEntitiesSigningWorkflowEvent();

        var result = new EntitiesSigningWorkflowsEventsValue
        {
            DomainId = domainId,
            EntityId = entityId,
            SigningId = signingId,
            ContractorSigned = contractorSigned
        };

        return result;
    }
}
