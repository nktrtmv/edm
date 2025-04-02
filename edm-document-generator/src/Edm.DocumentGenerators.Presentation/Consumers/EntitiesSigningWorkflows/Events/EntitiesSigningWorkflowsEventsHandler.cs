using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Events;

[UsedImplicitly]
internal sealed class EntitiesSigningWorkflowsEventsHandler(
    IMediator mediator,
    ILogger<EntitiesSigningWorkflowsEventsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        EntitiesSigningWorkflowsEventsValue? eventValue = EntitiesSigningWorkflowsEventsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            eventValue,
            async () =>
            {
                if (ShallBeSkipped(eventValue))
                {
                    return;
                }

                IRequest? command = EntitiesSigningWorkflowsEventsValueConverter.ToInternal(eventValue);

                await mediator.Send(command, context.ConsumerContext.WorkerStopped);
            });
    }

    private bool ShallBeSkipped(EntitiesSigningWorkflowsEventsValue value)
    {
        if (value.DomainId != DomainId.Contracts)
        {
            return true;
        }

        if (value.EventCase is not EntitiesSigningWorkflowsEventsValue.EventOneofCase.SelfSigned)
        {
            return true;
        }

        return false;
    }
}
