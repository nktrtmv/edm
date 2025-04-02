using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events.Converters;
using Edm.DocumentGenerators.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Consumers.DocumentGenerator.Events;

[UsedImplicitly]
internal sealed class DocumentGeneratorEventsHandler(IMediator mediator, ILogger<DocumentGeneratorEventsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        var value = DocumentGeneratorEventsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            value,
            async () =>
            {
                var command = DocumentGeneratorEventsValueConverter.ToInternal(value);

                if (command == null)
                {
                    return;
                }

                await mediator.Send(command, context.ConsumerContext.WorkerStopped);
            });
    }
}
