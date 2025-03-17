using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentGenerator.Events.Convertors;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events;
using Edm.DocumentGenerators.GenericSubdomain.Application.Events.Processors.Abstractions;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentGenerator.Events;

public sealed class DocumentGeneratorEventDocumentApplicationEventProcessor : ApplicationEventProcessorGeneric<Document, DocumentGeneratorEventDocumentApplicationEvent>
{
    public DocumentGeneratorEventDocumentApplicationEventProcessor(
        IDocumentGeneratorEventsSender sender,
        ILogger<DocumentGeneratorEventDocumentApplicationEventProcessor> logger)
        : base(logger)
    {
        Sender = sender;
    }

    private IDocumentGeneratorEventsSender Sender { get; }

    protected override async Task OnProcess(
        DocumentGeneratorEventDocumentApplicationEvent applicationEvent,
        Document document,
        CancellationToken cancellationToken)
    {
        DocumentGeneratorEvent? @event = DocumentGeneratorEventsConverter.FromDomain(applicationEvent, document);

        await Sender.Send(@event, cancellationToken);
    }
}
