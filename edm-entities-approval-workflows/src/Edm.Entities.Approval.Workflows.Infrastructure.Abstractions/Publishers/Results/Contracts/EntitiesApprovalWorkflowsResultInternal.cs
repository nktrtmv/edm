namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts;

public abstract record EntitiesApprovalWorkflowsResultInternal(
    string EntityId,
    string DomainId);
