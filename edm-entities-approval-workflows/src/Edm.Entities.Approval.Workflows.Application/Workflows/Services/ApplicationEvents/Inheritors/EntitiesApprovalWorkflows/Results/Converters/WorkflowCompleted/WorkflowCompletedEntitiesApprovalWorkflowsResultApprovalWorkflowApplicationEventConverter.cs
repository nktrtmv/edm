using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Infrastructure.Abstractions.Publishers.Results.Contracts.Inheritors.WorkflowCompleted;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Services.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Results.Converters.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventConverter
{
    internal static WorkflowCompletedEntitiesApprovalWorkflowsResultInternal FromDomain(
        WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent applicationEvent,
        ApprovalWorkflow workflow)
    {
        var result = new WorkflowCompletedEntitiesApprovalWorkflowsResultInternal(
            workflow.Parameters.Entity.Id,
            workflow.Parameters.Entity.DomainId,
            workflow.Id,
            workflow.Status,
            applicationEvent.CompletedByUserId,
            applicationEvent.CompletionComment);

        return result;
    }
}
