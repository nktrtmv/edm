using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Keys;
using Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests.Converters.Values;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.Entities.Signing.Workflows.Presentation.Abstractions;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesSigningWorkflows.Requests;

internal sealed class EntitiesSigningWorkflowsRequestsSender : IEntitiesSigningWorkflowsRequestsSender
{
    public EntitiesSigningWorkflowsRequestsSender(
        IMessageProducer<EntitiesSigningWorkflowsRequestsSender> producer,
        ILogger<EntitiesSigningWorkflowsRequestsSender> logger)
    {
        Producer = producer;
        Logger = logger;
    }

    private IMessageProducer<EntitiesSigningWorkflowsRequestsSender> Producer { get; }
    private ILogger<EntitiesSigningWorkflowsRequestsSender> Logger { get; }

    public async Task Send(EntitiesSigningWorkflowsRequestExternal request, CancellationToken cancellationToken)
    {
        EntitiesSigningWorkflowsRequestsKey? key = EntitiesSigningWorkflowsRequestsKeyConverter.FromExternal(request);

        EntitiesSigningWorkflowsRequestsValue? value = EntitiesSigningWorkflowsRequestsValueConverter.FromExternal(request);

        byte[]? byteKey = key.ToByteArray();

        byte[]? byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            Logger,
            nameof(Send),
            key,
            value,
            async () => await Producer.ProduceAsync(byteKey, byteValue));
    }
}
