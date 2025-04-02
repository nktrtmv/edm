using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Abstractions;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendSelfSigned;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.SelfSigned;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendSelfSigned;

public sealed class SendSelfSignedSigningApplicationEventProcessor : SigningApplicationEventProcessorGeneric<SendSelfSignedSigningApplicationEvent>
{
    public SendSelfSignedSigningApplicationEventProcessor(IEntitiesSigningWorkflowsEventsSender sender)
    {
        Sender = sender;
    }

    private IEntitiesSigningWorkflowsEventsSender Sender { get; }

    protected override async Task OnEvent(
        SigningWorkflow workflow,
        SendSelfSignedSigningApplicationEvent applicationEvent,
        CancellationToken cancellationToken)
    {
        var message = new SelfSignedEntitiesEntitiesSigningWorkflowsEventInternal(workflow.DomainId, workflow.EntityId, workflow.Id);

        await Sender.Send(message, cancellationToken);
    }
}
