using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendContractorSigned;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.ContractorSigned;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendContractorSigned;

public sealed class SendContractorSignedSigningApplicationEventProcessor(IEntitiesSigningWorkflowsEventsSender sender)
    : SigningApplicationEventProcessorGeneric<SendContractorSignedSigningApplicationEvent>
{
    protected override async Task OnEvent(
        SigningWorkflow workflow,
        SendContractorSignedSigningApplicationEvent applicationEvent,
        CancellationToken cancellationToken)
    {
        var message = new ContractorSignedEntitiesEntitiesSigningWorkflowsEventInternal(workflow.DomainId, workflow.EntityId, workflow.Id);

        await sender.Send(message, cancellationToken);
    }
}
