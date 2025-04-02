using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Abstractions;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Results.Converters;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Results;

public sealed class EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventProcessor
    : ApprovalWorkflowApplicationEventProcessorGeneric<EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent>
{
    public EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventProcessor(IEntitiesApprovalWorkflowsResultsSender sender)
    {
        Sender = sender;
    }

    private IEntitiesApprovalWorkflowsResultsSender Sender { get; }

    protected override Task OnEvent(
        EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent applicationEvent,
        ApprovalWorkflow workflow,
        CancellationToken cancellationToken)
    {
        var request =
            EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventConverter.FromDomain(applicationEvent, workflow);

        return Sender.Send(request, cancellationToken);
    }
}
