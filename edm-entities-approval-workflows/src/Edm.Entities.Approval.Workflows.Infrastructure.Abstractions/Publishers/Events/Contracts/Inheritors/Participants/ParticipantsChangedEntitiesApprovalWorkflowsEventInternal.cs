namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Participants;

public sealed record ParticipantsChangedEntitiesApprovalWorkflowsEventInternal(
    string EntityId,
    string DomainId) : EntitiesApprovalWorkflowsEventInternal(EntityId, DomainId);
