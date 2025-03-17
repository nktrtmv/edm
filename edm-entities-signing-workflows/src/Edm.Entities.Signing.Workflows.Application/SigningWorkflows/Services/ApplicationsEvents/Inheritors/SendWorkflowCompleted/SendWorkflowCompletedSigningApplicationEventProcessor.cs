using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Abstractions;
using Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendWorkflowCompleted.Converters;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Signing.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Inheritors.SendWorkflowCompleted;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results;
using Edm.Entities.Signing.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;

namespace Edm.Entities.Signing.Workflows.Application.SigningWorkflows.Services.ApplicationsEvents.Inheritors.SendWorkflowCompleted;

public sealed class SendWorkflowCompletedSigningApplicationEventProcessor : SigningApplicationEventProcessorGeneric<SendWorkflowCompletedSigningApplicationEvent>
{
    public SendWorkflowCompletedSigningApplicationEventProcessor(IEntitiesSigningWorkflowsResultsSender sender)
    {
        Sender = sender;
    }

    private IEntitiesSigningWorkflowsResultsSender Sender { get; }

    protected override async Task OnEvent(
        SigningWorkflow workflow,
        SendWorkflowCompletedSigningApplicationEvent applicationEvent,
        CancellationToken cancellationToken)
    {
        WorkflowCompletedEntitiesSigningWorkflowResultInternal result =
            WorkflowCompletedEntitiesSigningWorkflowResultInternalConverter.FromDomain(workflow, applicationEvent);

        await Sender.Send(result, cancellationToken);
    }
}
