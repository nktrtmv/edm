using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Abstractions;

public abstract class ApprovalWorkflowApplicationEventProcessorGeneric<T> : IApprovalWorkflowApplicationEventProcessor
    where T : ApprovalWorkflowApplicationEvent
{
    async Task IApprovalWorkflowApplicationEventProcessor.Process(
        int counter,
        ApprovalWorkflowApplicationEvent applicationEvent,
        ApprovalWorkflow workflow,
        CancellationToken cancellationToken)
    {
        if (applicationEvent is not T e)
        {
            return;
        }

        await OnEvent(e, workflow, cancellationToken);
    }

    protected abstract Task OnEvent(T applicationEvent, ApprovalWorkflow workflow, CancellationToken cancellationToken);
}
