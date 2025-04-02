using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results.Converters;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.DocumentGenerators.Presentation.Consumers.EntitiesApprovalWorkflows.Results;

[UsedImplicitly]
internal sealed class EntitiesApprovalWorkflowsResultsHandler(
    IMediator mediator,
    ILogger<EntitiesApprovalWorkflowsResultsHandler> logger)
    : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        EntitiesApprovalWorkflowsResultsValue? eventValue = EntitiesApprovalWorkflowsResultsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            eventValue,
            async () =>
            {
                if (eventValue.DomainId != DomainId.Contracts)
                {
                    return;
                }

                IRequest? result = EntitiesApprovalWorkflowsResultsValueConverter.ToInternal(eventValue);

                await mediator.Send(result, context.ConsumerContext.WorkerStopped);
            });
    }
}
