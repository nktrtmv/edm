using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;
using Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events.Converters.Keys;
using Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events.Converters.Values;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events;

internal sealed class DocumentGeneratorEventsSender(IMessageProducer<DocumentGeneratorEventsSender> producer, ILogger<DocumentGeneratorEventsSender> logger)
    : IDocumentGeneratorEventsSender
{
    public Task Send(DocumentGeneratorEvent @event, CancellationToken cancellationToken)
    {
        DocumentGeneratorEventsKey key = DocumentGeneratorEventsKeyConverter.FromDomain(@event);
        DocumentGeneratorEventsValue value = DocumentGeneratorEventsValueConverter.FromDomain(@event);

        byte[]? byteKey = key.ToByteArray();
        byte[]? byteValue = value.ToByteArray();

        return TracingFacility.TraceKafkaProducer(
            logger,
            nameof(Send),
            key,
            value,
            async () => await producer.ProduceAsync(byteKey, byteValue));
    }
}
