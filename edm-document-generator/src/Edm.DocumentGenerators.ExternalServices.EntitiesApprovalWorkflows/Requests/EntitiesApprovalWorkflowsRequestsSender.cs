using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Keys;
using Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Converters.Values;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests;

internal sealed class EntitiesApprovalWorkflowsRequestsSender(
    IMessageProducer<EntitiesApprovalWorkflowsRequestsSender> producer,
    ILogger<EntitiesApprovalWorkflowsRequestsSender> logger) : IEntitiesApprovalWorkflowsRequestsSender
{
    public async Task Send(EntitiesApprovalWorkflowsRequestExternal request, CancellationToken cancellationToken)
    {
        EntitiesApprovalWorkflowsRequestsKey? key = EntitiesApprovalWorkflowsRequestsKeyConverter.FromExternal(request);

        EntitiesApprovalWorkflowsRequestsValue? value = EntitiesApprovalWorkflowsRequestsValueConverter.FromExternal(request);

        byte[]? byteKey = key.ToByteArray();

        byte[]? byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            logger,
            nameof(Send),
            key,
            value,
            async () => await producer.ProduceAsync(byteKey, byteValue));
    }
}
