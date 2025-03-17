using Edm.Entities.Signing.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Keys;
using Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results.Converters.Values;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Signing.Workflows.Presentation.Publisher.Producers.SigningWorkflows.Results;

internal sealed class EntitiesSigningWorkflowsResultsSender(
    IMessageProducer<EntitiesSigningWorkflowsResultsSender> producer,
    ILogger<EntitiesSigningWorkflowsResultsSender> logger) : IEntitiesSigningWorkflowsResultsSender
{
    async Task IEntitiesSigningWorkflowsResultsSender.Send(EntitiesSigningWorkflowsResultInternal message, CancellationToken cancellationToken)
    {
        EntitiesSigningWorkflowsResultsKey key = EntitiesSigningWorkflowsResultsKeyConverter.FromInternal(message);
        EntitiesSigningWorkflowsResultsValue value = EntitiesSigningWorkflowsResultsValueConverter.FromInternal(message);

        byte[]? byteKey = key.ToByteArray();
        byte[]? byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            logger,
            nameof(IEntitiesSigningWorkflowsResultsSender.Send),
            key,
            value,
            () => producer.ProduceAsync(byteKey, byteValue));
    }
}
