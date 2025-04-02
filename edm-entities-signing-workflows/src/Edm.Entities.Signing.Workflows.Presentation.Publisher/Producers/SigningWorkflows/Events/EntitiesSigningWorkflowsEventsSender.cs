using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Keys;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events.Converters.Values;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Events;

internal sealed class EntitiesSigningWorkflowsEventsSender(
    IMessageProducer<EntitiesSigningWorkflowsEventsSender> producer,
    ILogger<EntitiesSigningWorkflowsEventsSender> logger) : IEntitiesSigningWorkflowsEventsSender
{
    async Task IEntitiesSigningWorkflowsEventsSender.Send(EntitiesSigningWorkflowsEventInternal message, CancellationToken cancellationToken)
    {
        EntitiesSigningWorkflowsEventsKey key = EntitiesSigningWorkflowsEventsKeyConverter.FromInternal(message);
        EntitiesSigningWorkflowsEventsValue value = EntitiesSigningWorkflowsEventsValueConverter.FromInternal(message);

        byte[]? byteKey = key.ToByteArray();
        byte[]? byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            logger,
            nameof(IEntitiesSigningWorkflowsEventsSender.Send),
            key,
            value,
            () => producer.ProduceAsync(byteKey, byteValue));
    }
}
