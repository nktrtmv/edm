namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Events.Contracts;

public abstract record EntitiesApprovalWorkflowsEventInternal(
    string EntityId,
    string DomainId);
