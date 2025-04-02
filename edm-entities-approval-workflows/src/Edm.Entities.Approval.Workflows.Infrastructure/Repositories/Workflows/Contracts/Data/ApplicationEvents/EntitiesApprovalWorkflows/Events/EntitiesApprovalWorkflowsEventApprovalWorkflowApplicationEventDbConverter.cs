using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.StageChanged;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Events.ParticipantsChanged;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Events.StageChanged;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Events;

internal static class EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter
{
    internal static ApprovalWorkflowApplicationEventDb FromDomain(EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent applicationEvent)
    {
        EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb asEntitiesApprovalWorkflowsEvent = applicationEvent switch
        {
            ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent e =>
                ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter.FromDomain(e),

            StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent e =>
                StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter.FromDomain(e),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        var result = new ApprovalWorkflowApplicationEventDb
        {
            AsEntitiesApprovalWorkflowsEvent = asEntitiesApprovalWorkflowsEvent
        };

        return result;
    }

    internal static EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent ToDomain(
        EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb applicationEvent)
    {
        EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent result = applicationEvent.EventCase switch
        {
            EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb.EventOneofCase.AsParticipantsChanged =>
                ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter.ToDomain(applicationEvent.AsParticipantsChanged),

            EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb.EventOneofCase.AsStageChanged =>
                StageChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter.ToDomain(applicationEvent.AsStageChanged),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent.EventCase)
        };

        return result;
    }
}
