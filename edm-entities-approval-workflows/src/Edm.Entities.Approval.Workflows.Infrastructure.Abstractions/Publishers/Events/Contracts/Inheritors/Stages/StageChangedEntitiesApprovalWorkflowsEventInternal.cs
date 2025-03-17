namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts.Inheritors.Stages;

public sealed record StageChangedEntitiesApprovalWorkflowsEventInternal(
    string EntityId,
    string DomainId) : EntitiesApprovalWorkflowsEventInternal(EntityId, DomainId);
