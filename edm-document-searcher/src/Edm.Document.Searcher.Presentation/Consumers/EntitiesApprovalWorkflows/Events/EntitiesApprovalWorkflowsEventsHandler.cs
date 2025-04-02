using Edm.Document.Searcher.Domain.Documents.ValueObjects;
using Edm.Document.Searcher.ExternalServices.DocumentClassifier.Domains;
using Edm.Document.Searcher.GenericSubdomain.Tracing;
using Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events.Converters;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.Document.Searcher.Presentation.Consumers.EntitiesApprovalWorkflows.Events;

[UsedImplicitly]
internal sealed class EntitiesApprovalWorkflowsEventsHandler(IMediator mediator, ILogger<EntitiesApprovalWorkflowsEventsHandler> logger, IDomainsClient domainsClient)
    : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        var value = EntitiesApprovalWorkflowsEventsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            value,
            async () =>
            {
                var isDomainExists = await domainsClient.CheckDomainExists(value.DomainId, context.ConsumerContext.WorkerStopped);

                if (!isDomainExists)
                {
                    return;
                }

                var command = EntitiesApprovalWorkflowsEventsValueConverter.ToInternal(value);

                if (command is null)
                {
                    return;
                }

                await mediator.Send(command, context.ConsumerContext.WorkerStopped);
            });
    }
}
