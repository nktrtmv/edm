using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Participants;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Events.Converters.Values.ParticipantsChanged;

internal static class ParticipantsChangedEntitiesApprovalWorkflowsEventConverter
{
    internal static EntitiesApprovalWorkflowsEventsValue FromDomain(
        ParticipantsChangedEntitiesApprovalWorkflowsEventInternal request,
        string domainId)
    {
        var asParticipantsChanged = new ParticipantsChangedEntitiesApprovalWorkflowsEvent
        {
            EntityId = request.EntityId
        };

        var result = new EntitiesApprovalWorkflowsEventsValue
        {
            DomainId = domainId,
            AsParticipantsChanged = asParticipantsChanged
        };

        return result;
    }
}
