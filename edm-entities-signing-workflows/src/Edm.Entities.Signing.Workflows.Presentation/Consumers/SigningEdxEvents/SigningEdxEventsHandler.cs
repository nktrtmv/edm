using Edm.Entities.Signing.Edx.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningEdx.Events.DocumentsStatusChanged.Contracts;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents.Contracts;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.SigningEdxEvents;

[UsedImplicitly]
public sealed class SigningEdxEventsHandler(IMediator mediator, ILogger<SigningEdxEventsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        SigningEdxEventValue? eventValue = SigningEdxEventValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            eventValue,
            async () =>
            {
                if (IsProcessingShallBeSkipped(eventValue))
                {
                    return;
                }

                DocumentsStatusChangedEventInternalCommand request =
                    DocumentsStatusChangedEventInternalCommandConverter.FromDto(eventValue.AsDocumentsStatusChanged);

                await mediator.Send(request, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool IsProcessingShallBeSkipped(SigningEdxEventValue value)
    {
        if (value.EventCase != SigningEdxEventValue.EventOneofCase.AsDocumentsStatusChanged)
        {
            return true;
        }

        return false;
    }
}
