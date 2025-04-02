using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Document.Searcher.Presentation.Consumers.EntitiesSigningWorkflows.Events.Converters;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesSigningWorkflows.Events;

[UsedImplicitly]
internal sealed class EntitiesSigningWorkflowsEventsHandler(IMediator mediator, ILogger<EntitiesSigningWorkflowsEventsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        var value = EntitiesSigningWorkflowsEventsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            value,
            async () =>
            {
                if (ShallBeSkipped(value))
                {
                    return;
                }

                var command = EntitiesSigningWorkflowsEventsValueConverter.ToInternal(value);

                await mediator.Send(command, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool ShallBeSkipped(EntitiesSigningWorkflowsEventsValue value)
    {
        if (value.DomainId != DomainId.ContractsDomain || value.EventCase is not EntitiesSigningWorkflowsEventsValue.EventOneofCase.ContractorSigned)
        {
            return true;
        }

        return false;
    }
}
