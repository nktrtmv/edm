using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Requests.Abstractions;
using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests.Converters;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.Entities.Signing.Workflows.Presentation.Consumers.Requests;

[UsedImplicitly]
internal sealed class EntitiesSigningWorkflowsRequestsHandler(IMediator mediator, ILogger<EntitiesSigningWorkflowsRequestsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        EntitiesSigningWorkflowsRequestsValue eventValue = EntitiesSigningWorkflowsRequestsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            eventValue,
            async () =>
            {
                EntitiesSigningWorkflowsRequestInternal request = SigningWorkflowsRequestsConverter.ToInternal(eventValue);

                await mediator.Send(request, context.ConsumerContext.WorkerStopped);
            });
    }
}
