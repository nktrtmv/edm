using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Events.ParticipantsChanged;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Events.ParticipantsChanged;

internal static class ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDbConverter
{
    internal static EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb FromDomain(
        ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent applicationEvent)
    {
        var asParticipantsChanged = new ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb();

        var result = new EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb
        {
            AsParticipantsChanged = asParticipantsChanged
        };

        return result;
    }

    internal static EntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent ToDomain(
        ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEventDb applicationEvent)
    {
        var result = new ParticipantsChangedEntitiesApprovalWorkflowsEventApprovalWorkflowApplicationEvent();

        return result;
    }
}
