using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx.Converters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendDocumentsToEdx;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx;
using Edm.Entities.Signing.Workflows.ExternalServices.EntitiesSigningEdx.Contracts;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendDocumentsToEdx;

public sealed class SendDocumentsToEdxSigningApplicationEventProcessor : SigningApplicationEventProcessorGeneric<SendDocumentsToEdxSigningApplicationEvent>
{
    public SendDocumentsToEdxSigningApplicationEventProcessor(IEntitiesSigningEdxClient client)
    {
        Client = client;
    }

    private IEntitiesSigningEdxClient Client { get; }

    protected override async Task OnEvent(
        SigningWorkflow workflow,
        SendDocumentsToEdxSigningApplicationEvent applicationEvent,
        CancellationToken cancellationToken)
    {
        SendSigningEdxDocumentsCommandExternal command = SendSigningEdxDocumentsCommandExternalConverter.FromDomain(workflow, applicationEvent);

        await Client.SendDocuments(command, cancellationToken);
    }
}
