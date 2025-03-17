using Edm.Entities.Approval.Workflows.GenericSubdomain.Tracing;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests;

[UsedImplicitly]
internal sealed class EntitiesApprovalWorkflowsRequestsHandler(
    IMediator mediator,
    ILogger<EntitiesApprovalWorkflowsRequestsHandler> logger) : IMessageHandler<byte[]>
{
    public async Task Handle(IMessageContext context, byte[] message)
    {
        var value = EntitiesApprovalWorkflowsRequestsValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            logger,
            nameof(Handle),
            context,
            value,
            async () =>
            {
                if (!IsValidRoute(value))
                {
                    throw new ApplicationException(
                        $"""
                         Route is null.
                         WorkflowId: {value.AsCreateWorkflow.WorkflowId}
                         """);
                }

                var request = EntitiesApprovalWorkflowsRequestsConverter.ToInternal(value);

                await mediator.Send(request, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool IsValidRoute(EntitiesApprovalWorkflowsRequestsValue value)
    {
        if (value.RequestCase is not EntitiesApprovalWorkflowsRequestsValue.RequestOneofCase.AsCreateWorkflow)
        {
            return true;
        }

        var request = value.AsCreateWorkflow;

        if (request.FindRouteResponse?.Route is not null)
        {
            return true;
        }

        return false;
    }
}
