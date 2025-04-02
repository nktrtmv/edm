using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Abstractions;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Events.StageChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.StageChanged;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;

using JetBrains.Annotations;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Events;

[UsedImplicitly]
public class EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventProcessor
    : ApprovalWorkflowApplicationEventProcessorGeneric<EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent>
{
    public EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventProcessor(IEntitiesApprovalWorkflowsEventsSender sender)
    {
        Sender = sender;
    }

    private IEntitiesApprovalWorkflowsEventsSender Sender { get; }

    protected override Task OnEvent(
        EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent applicationEvent,
        ApprovalWorkflow workflow,
        CancellationToken cancellationToken)
    {
        EntitiesApprovalWorkflowsEventInternal @event = applicationEvent switch
        {
            ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent =>
                ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventConverter.FromDomain(workflow),

            StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent =>
                StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventConverter.FromDomain(workflow),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return Sender.Send(@event, cancellationToken);
    }
}
