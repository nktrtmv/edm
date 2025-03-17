using Edm.Entities.Approval.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Keys;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Results;

internal sealed class EntitiesApprovalWorkflowsResultsSender(
    IMessageProducer<EntitiesApprovalWorkflowsResultsSender> sender,
    ILogger<EntitiesApprovalWorkflowsResultsSender> logger) : IEntitiesApprovalWorkflowsResultsSender
{
    public async Task Send(EntitiesApprovalWorkflowsResultInternal request, CancellationToken cancellationToken)
    {
        var key = EntitiesApprovalWorkflowsResultsKeyConverter.FromDomain(request);
        var value = EntitiesApprovalWorkflowsResultsValueConverter.FromDomain(request);

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
