using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Abstractions;

public abstract class SigningApplicationEventProcessorGeneric<T> : ISigningApplicationEventProcessor
    where T : SigningApplicationEvent
{
    async Task ISigningApplicationEventProcessor.Process(
        SigningApplicationEvent applicationEvent,
        SigningWorkflow workflow,
        CancellationToken cancellationToken)
    {
        if (applicationEvent is not T e)
        {
            return;
        }

        await OnEvent(workflow, e, cancellationToken);
    }

    protected abstract Task OnEvent(SigningWorkflow workflow, T applicationEvent, CancellationToken cancellationToken);
}
