using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values.WorkflowCompleted.States.Statuses;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values.WorkflowCompleted.States;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultStateConverter
{
    internal static WorkflowCompletedEntitiesApprovalWorkflowsResultState FromDomain(ApprovalWorkflowStatus statusInternal)
    {
        WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus
            status = WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatusConverter.FromDomain(statusInternal);

        var result = new WorkflowCompletedEntitiesApprovalWorkflowsResultState
        {
            Status = status
        };

        return result;
    }
}
