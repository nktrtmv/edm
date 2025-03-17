using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.GenericSubdomain.Exceptions;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Entities.Approval.Workflows.Presentation.Publisher.Results.Converters.Values.WorkflowCompleted.States.Statuses;

internal static class WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatusConverter
{
    internal static WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus FromDomain(ApprovalWorkflowStatus status)
    {
        WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus result = status switch
        {
            ApprovalWorkflowStatus.Approved => WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.Approved,
            ApprovalWorkflowStatus.Rejected => WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.Rejected,
            ApprovalWorkflowStatus.ReturnedToRework => WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.ReturnedToRework,
            ApprovalWorkflowStatus.ApprovedWithRemark => WorkflowCompletedEntitiesApprovalWorkflowsResultStateStatus.ApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
