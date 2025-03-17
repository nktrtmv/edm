using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentNotifier.Requests.SendNotification.Converters;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentNotifier.Requests.SendNotification;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier;
using Edm.DocumentGenerators.ExternalServices.DocumentsNotifier.Requests.Contracts.Inheritors.SendNotification;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentNotifier.Requests.SendNotification;

public sealed class SendNotificationDocumentNotifierRequestDocumentApplicationEventProcessor
    : ApplicationEventProcessorGeneric<Document, SendNotificationDocumentNotifierRequestDocumentApplicationEvent>
{
    public SendNotificationDocumentNotifierRequestDocumentApplicationEventProcessor(
        IDocumentNotifierRequestsSender client,
        ILogger<SendNotificationDocumentNotifierRequestDocumentApplicationEventProcessor> logger) : base(logger)
    {
        Client = client;
    }

    private IDocumentNotifierRequestsSender Client { get; }

    protected override async Task OnProcess(
        SendNotificationDocumentNotifierRequestDocumentApplicationEvent applicationEvent,
        Document document,
        CancellationToken cancellationToken)
    {
        SendNotificationDocumentNotifierRequestExternal? command =
            SendNotificationDocumentNotifierRequestExternalConverter.FromDomain(applicationEvent, document);

        await Client.Send(command, cancellationToken);
    }
}
