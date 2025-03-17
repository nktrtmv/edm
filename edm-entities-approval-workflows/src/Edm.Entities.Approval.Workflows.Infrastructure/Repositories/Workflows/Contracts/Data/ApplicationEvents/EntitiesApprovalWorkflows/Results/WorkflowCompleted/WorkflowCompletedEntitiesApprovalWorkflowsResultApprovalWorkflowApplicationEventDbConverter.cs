using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.ApplicationEvents.Workflows.Results.WorkflowCompleted;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.ApplicationEvents.EntitiesApprovalWorkflows.Results.WorkflowCompleted;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDbConverter
{
    internal static EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb FromDomain(
        WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent applicationEvent)
    {
        var completedByUserId = applicationEvent.CompletedByUserId.ToString();

        var asWorkflowCompleted = new WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb
        {
            CompletedByUserId = completedByUserId,
            CompletionComment = applicationEvent.CompletionComment
        };

        var result = new EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb
        {
            AsWorkflowCompleted = asWorkflowCompleted
        };

        return result;
    }

    internal static EntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent ToDomain(
        WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEventDb applicationEvent)
    {
        Id<Employee> completedByUserId = IdConverterFrom<Employee>.FromString(applicationEvent.CompletedByUserId);

        var result = new WorkflowCompletedEntitiesApprovalWorkflowsResultApprovalWorkflowApplicationEvent(completedByUserId, applicationEvent.CompletionComment);

        return result;
    }
}
