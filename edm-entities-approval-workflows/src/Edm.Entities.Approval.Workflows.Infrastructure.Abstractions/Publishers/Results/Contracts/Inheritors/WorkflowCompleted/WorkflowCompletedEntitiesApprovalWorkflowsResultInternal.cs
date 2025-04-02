using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;

public sealed record WorkflowCompletedEntitiesApprovalWorkflowsResultInternal(
    string EntityId,
    string DomainId,
    Id<ApprovalWorkflow> WorkflowId,
    ApprovalWorkflowStatus Status,
    Id<Employee> CompletedByUserId,
    string? CompletionComment)
    : EntitiesApprovalWorkflowsResultInternal(EntityId, DomainId);
