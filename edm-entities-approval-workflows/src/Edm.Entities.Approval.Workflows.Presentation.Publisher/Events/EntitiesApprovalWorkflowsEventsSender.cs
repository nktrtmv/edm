using Edm.Entities.Approval.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Keys;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Values;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Events;

internal sealed class EntitiesApprovalWorkflowsEventsSender(
    IMessageProducer<EntitiesApprovalWorkflowsEventsSender> sender,
    ILogger<EntitiesApprovalWorkflowsEventsSender> logger) : IEntitiesApprovalWorkflowsEventsSender
{
    public async Task Send(EntitiesApprovalWorkflowsEventInternal request, CancellationToken cancellationToken)
    {
        var key = EntitiesApprovalWorkflowsEventsKeyConverter.FromDomain(request);
        var value = EntitiesApprovalWorkflowsEventsValueConverter.FromDomain(request);

        var byteKey = key.ToByteArray();
        var byteValue = value.ToByteArray();

        await TracingFacility.TraceKafkaProducer(
            logger,
            nameof(Send),
            key,
            value,
            () => sender.ProduceAsync(byteKey, byteValue));
    }
}
