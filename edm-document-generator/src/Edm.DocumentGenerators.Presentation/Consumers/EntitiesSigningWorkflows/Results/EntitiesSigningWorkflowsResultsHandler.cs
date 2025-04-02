using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results.Converters;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesSigningWorkflows.Results;

[UsedImplicitly]
internal sealed class EntitiesSigningWorkflowsResultsHandler(IMediator mediator, ILogger<EntitiesSigningWorkflowsResultsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        EntitiesSigningWorkflowsResultsValue? eventValue = EntitiesSigningWorkflowsResultsValue.Parser.ParseFrom(message);

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

                IRequest? command = EntitiesSigningWorkflowsResultsValueConverter.ToInternal(eventValue);

                await mediator.Send(command, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool ShallBeSkipped(EntitiesSigningWorkflowsResultsValue value)
    {
        if (value.DomainId != DomainId.Contracts)
        {
            return true;
        }

        if (value.ResultCase is not EntitiesSigningWorkflowsResultsValue.ResultOneofCase.WorkflowCompleted)
        {
            return true;
        }

        return false;
    }
}
